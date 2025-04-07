using Heal.Domain.Shared.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict;
using Volo.Abp.OpenIddict.Controllers;
using Volo.Abp.OpenIddict.ExtensionGrantTypes;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Uow;
using Volo.Abp.Validation;
using IdentityUser = Volo.Abp.Identity.IdentityUser;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace Heal.Net.AuthServer.ExtensionGrantTypes;

/// <summary>
/// 自定义登录方式(Pat)
/// </summary>
[IgnoreAntiforgeryToken]
[ApiExplorerSettings(IgnoreApi = true)]
public class HealPatAppExtensionGrant : AbpOpenIdDictControllerBase, ITokenExtensionGrant
{
    /// <summary>
    /// 服务作用域
    /// </summary>
    protected IServiceScopeFactory ServiceScopeFactory => LazyServiceProvider.LazyGetRequiredService<IServiceScopeFactory>();

    /// <summary>
    /// 租户配置提供者
    /// </summary>
    protected ITenantConfigurationProvider TenantConfigurationProvider => LazyServiceProvider.LazyGetRequiredService<ITenantConfigurationProvider>();

    /// <summary>
    /// Abp身份验证配置
    /// </summary>
    protected IOptions<AbpIdentityOptions> AbpIdentityOptions => LazyServiceProvider.LazyGetRequiredService<IOptions<AbpIdentityOptions>>();

    /// <summary>
    /// Identity身份验证配置
    /// </summary>
    protected IOptions<IdentityOptions> IdentityOptions => LazyServiceProvider.LazyGetRequiredService<IOptions<IdentityOptions>>();

    /// <summary>
    /// 身份安全日志管理器
    /// </summary>
    protected IdentitySecurityLogManager IdentitySecurityLogManager => LazyServiceProvider.LazyGetRequiredService<IdentitySecurityLogManager>();

    /// <summary>
    /// 设置提供者
    /// </summary>
    protected ISettingProvider SettingProvider => LazyServiceProvider.LazyGetRequiredService<ISettingProvider>();

    /// <summary>
    /// 动态身份验证主键提供者缓存
    /// </summary>
    protected IdentityDynamicClaimsPrincipalContributorCache IdentityDynamicClaimsPrincipalContributorCache => LazyServiceProvider.LazyGetRequiredService<IdentityDynamicClaimsPrincipalContributorCache>();

    /// <summary>
    /// 处理密码
    /// </summary>
    /// <param name="request">request</param>
    /// <returns>IActionResult</returns>
    [UnitOfWork] // UnitOfWork表示工单提交(事务)
    protected virtual async Task<IActionResult> HandlePasswordAsync(OpenIddictRequest request)
    {
        if (request.Username == null || request.Password == null)
        {
            var items = new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "Invalid username or password!"
            };
            var properties = new AuthenticationProperties(items!);

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        using var scope = ServiceScopeFactory.CreateScope();
        var tenant = await TenantConfigurationProvider.GetAsync(saveResolveResult: false);

        using (CurrentTenant.Change(tenant?.Id))
        {
            await ReplaceEmailToUsernameOfInputIfNeeds(request);

            IdentityUser? user;
            if (AbpIdentityOptions.Value.ExternalLoginProviders.Any())
            {
                foreach (var externalLoginProviderInfo in AbpIdentityOptions.Value.ExternalLoginProviders.Values)
                {
                    var externalLoginProvider = (IExternalLoginProvider)scope.ServiceProvider
                        .GetRequiredService(externalLoginProviderInfo.Type);

                    if (await externalLoginProvider.TryAuthenticateAsync(request.Username, request.Password))
                    {
                        user = await UserManager.FindByNameAsync(request.Username);
                        if (user == null)
                        {
                            user = await externalLoginProvider.CreateUserAsync(request.Username, externalLoginProviderInfo.Name);
                        }
                        else
                        {
                            await externalLoginProvider.UpdateUserAsync(user, externalLoginProviderInfo.Name);
                        }

                        return await SetSuccessResultAsync(request, user);
                    }
                }
            }

            await IdentityOptions.SetAsync();

            user = await UserManager.FindByNameAsync(request.Username);
            if (user == null)
            {
                Logger.LogInformation("No user found matching username: {username}", request.Username);

                var properties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "Invalid username or password!"
                }!);

                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext()
                {
                    Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                    Action = OpenIddictSecurityLogActionConsts.LoginInvalidUserName,
                    UserName = request.Username,
                    ClientId = request.ClientId
                });

                return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            var result = await SignInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (!result.Succeeded)
            {
                await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                {
                    Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                    Action = result.ToIdentitySecurityLogAction(),
                    UserName = request.Username,
                    ClientId = request.ClientId
                });

                string errorDescription;
                if (result.IsLockedOut)
                {
                    Logger.LogInformation("Authentication failed for username: {username}, reason: locked out", request.Username);
                    errorDescription = "The user account has been locked out due to invalid login attempts. Please wait a while and try again.";
                }
                else if (result.IsNotAllowed)
                {
                    if (!await UserManager.CheckPasswordAsync(user, request.Password))
                    {
                        Logger.LogInformation("Authentication failed for username: {username}, reason: invalid credentials", request.Username);
                        errorDescription = "Invalid username or password!";
                    }
                    else
                    {
                        Logger.LogInformation("Authentication failed for username: {username}, reason: not allowed", request.Username);

                        if (user.ShouldChangePasswordOnNextLogin)
                        {
                            return await HandleShouldChangePasswordOnNextLoginAsync(request, user, request.Password);
                        }

                        if (await UserManager.ShouldPeriodicallyChangePasswordAsync(user))
                        {
                            return await HandlePeriodicallyChangePasswordAsync(request, user, request.Password);
                        }

                        if (user.IsActive)
                        {
                            return await HandleConfirmUserAsync(request, user);
                        }

                        errorDescription = "You are not allowed to login! Your account is inactive.";
                    }
                }
                else
                {
                    Logger.LogInformation("Authentication failed for username: {username}, reason: invalid credentials", request.Username);
                    errorDescription = "Invalid username or password!";
                }

                var properties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = errorDescription
                }!);

                return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            if (await IsTfaEnabledAsync(user))
            {
                return await HandleTwoFactorLoginAsync(request, user);
            }

            return await SetSuccessResultAsync(request, user);
        }
    }

    /// <summary>
    /// Replace email to username of input if needs
    /// </summary>
    /// <param name="request">request</param>
    /// <returns>Task</returns>
    protected virtual async Task ReplaceEmailToUsernameOfInputIfNeeds(OpenIddictRequest request)
    {
        if (!ValidationHelper.IsValidEmailAddress(request.Username!))
        {
            return;
        }

        var userByUsername = await UserManager.FindByNameAsync(request.Username!);
        if (userByUsername != null)
        {
            return;
        }

        var userByEmail = await UserManager.FindByEmailAsync(request.Username!);
        if (userByEmail == null)
        {
            return;
        }

        request.Username = userByEmail.UserName;
    }

    /// <summary>
    /// Handle two factor login
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <returns>IActionResult</returns>
    protected virtual async Task<IActionResult> HandleTwoFactorLoginAsync(OpenIddictRequest request, IdentityUser user)
    {
        var recoveryCode = request.GetParameter("RecoveryCode")?.ToString();
        if (!recoveryCode.IsNullOrWhiteSpace())
        {
            var result = await UserManager.RedeemTwoFactorRecoveryCodeAsync(user, recoveryCode);
            if (result.Succeeded)
            {
                return await SetSuccessResultAsync(request, user);
            }

            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "Invalid recovery code!"
            }!);

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        var twoFactorProvider = request.GetParameter("TwoFactorProvider")?.ToString();
        var twoFactorCode = request.GetParameter("TwoFactorCode")?.ToString();
        if (!twoFactorProvider.IsNullOrWhiteSpace() && !twoFactorCode.IsNullOrWhiteSpace())
        {
            var providers = await UserManager.GetValidTwoFactorProvidersAsync(user);
            if (providers.Contains(twoFactorProvider) && await UserManager.VerifyTwoFactorTokenAsync(user, twoFactorProvider, twoFactorCode))
            {
                return await SetSuccessResultAsync(request, user);
            }

            await UserManager.AccessFailedAsync(user);

            Logger.LogInformation("Authentication failed for username: {username}, reason: InvalidAuthenticatorCode", request.Username);

            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "Invalid authenticator code!"
            }!);

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
        else
        {
            Logger.LogInformation("Authentication failed for username: {username}, reason: RequiresTwoFactor", request.Username);
            var twoFactorToken = await UserManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, nameof(SignInResult.RequiresTwoFactor));

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            {
                Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                Action = OpenIddictSecurityLogActionConsts.LoginRequiresTwoFactor,
                UserName = request.Username,
                ClientId = request.ClientId
            });

            var properties = new AuthenticationProperties(
                items: new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = AbpErrorDescriptionConsts.RequiresTwoFactor
                }!,
                parameters: new Dictionary<string, object>
                {
                    ["userId"] = user.Id.ToString("N"),
                    ["twoFactorToken"] = twoFactorToken
                }!);

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
    }

    /// <summary>
    /// Should change password on next login
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <param name="currentPassword">currentPassword</param>
    /// <returns>IActionResult</returns>
    protected virtual async Task<IActionResult> HandleShouldChangePasswordOnNextLoginAsync(OpenIddictRequest request, IdentityUser user, string currentPassword)
    {
        return await HandleChangePasswordAsync(request, user, currentPassword, ChangePasswordType.ShouldChangePasswordOnNextLogin);
    }

    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <param name="currentPassword">currentPassword</param>
    /// <returns>IActionResult</returns>
    protected virtual async Task<IActionResult> HandlePeriodicallyChangePasswordAsync(OpenIddictRequest request, IdentityUser user, string currentPassword)
    {
        return await HandleChangePasswordAsync(request, user, currentPassword, ChangePasswordType.PeriodicallyChangePassword);
    }

    /// <summary>
    /// Change password
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <param name="currentPassword">currentPassword</param>
    /// <param name="changePasswordType">changePasswordType</param>
    /// <returns>IActionResult</returns>
    protected virtual async Task<IActionResult> HandleChangePasswordAsync(OpenIddictRequest request, IdentityUser user, string currentPassword, ChangePasswordType changePasswordType)
    {
        var changePasswordToken = request.GetParameter("ChangePasswordToken")?.ToString();
        var newPassword = request.GetParameter("NewPassword")?.ToString();
        if (!changePasswordToken.IsNullOrWhiteSpace() && !currentPassword.IsNullOrWhiteSpace() && !newPassword.IsNullOrWhiteSpace())
        {
            if (await UserManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, changePasswordType.ToString(), changePasswordToken))
            {
                var changePasswordResult = await UserManager.ChangePasswordAsync(user, currentPassword, newPassword);
                if (changePasswordResult.Succeeded)
                {
                    await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
                    {
                        Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                        Action = IdentitySecurityLogActionConsts.ChangePassword,
                        UserName = request.Username,
                        ClientId = request.ClientId
                    });

                    if (changePasswordType == ChangePasswordType.ShouldChangePasswordOnNextLogin)
                    {
                        user.SetShouldChangePasswordOnNextLogin(false);
                    }

                    await UserManager.UpdateAsync(user);
                    return await SetSuccessResultAsync(request, user);
                }
                else
                {
                    Logger.LogInformation("ChangePassword failed for username: {username}, reason: {changePasswordResult}", request.Username, changePasswordResult.Errors.Select(x => x.Description).JoinAsString(", "));

                    var properties = new AuthenticationProperties(new Dictionary<string, string>
                    {
                        [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                        [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = changePasswordResult.Errors.Select(x => x.Description).JoinAsString(", ")
                    }!);
                    return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
                }
            }
            else
            {
                Logger.LogInformation("Authentication failed for username: {username}, reason: InvalidAuthenticatorCode", request.Username);

                var properties = new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "Invalid authenticator code!"
                }!);

                return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }
        }
        else
        {
            Logger.LogInformation($"Authentication failed for username: {{{request.Username}}}, reason: {{{changePasswordType.ToString()}}}");

            await IdentitySecurityLogManager.SaveAsync(new IdentitySecurityLogContext
            {
                Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                Action = OpenIddictSecurityLogActionConsts.LoginNotAllowed,
                UserName = request.Username,
                ClientId = request.ClientId
            });

            var properties = new AuthenticationProperties(
                items: new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = changePasswordType.ToString()
                }!,
                parameters: new Dictionary<string, object>
                {
                    ["userId"] = user.Id.ToString("N"),
                    ["changePasswordToken"] = await UserManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, changePasswordType.ToString())
                }!);

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }
    }

    /// <summary>
    /// Confirm user
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <returns>IActionResult</returns>
    protected virtual Task<IActionResult> HandleConfirmUserAsync(OpenIddictRequest request, IdentityUser user)
    {
        Logger.LogInformation($"{request.Username} needs to confirm email/phone number");

        var properties = new AuthenticationProperties(
            items: new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = AbpErrorDescriptionConsts.RequiresConfirmUser
            }!,
            parameters: new Dictionary<string, object>
            {
                ["userId"] = user.Id.ToString("N"),
                ["email"] = user.Email,
                ["phoneNumber"] = user.PhoneNumber ?? ""
            }!);

        return Task.FromResult<IActionResult>(Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme));
    }

    /// <summary>
    /// Set success result
    /// </summary>
    /// <param name="request">request</param>
    /// <param name="user">user</param>
    /// <returns>IActionResult</returns>
    protected virtual async Task<IActionResult> SetSuccessResultAsync(OpenIddictRequest request, IdentityUser user)
    {
        // Clear the dynamic claims cache.
        await IdentityDynamicClaimsPrincipalContributorCache.ClearAsync(user.Id, user.TenantId);

        // Create a new ClaimsPrincipal containing the claims that
        // will be used to create an id_token, a token or a code.
        var principal = await SignInManager.CreateUserPrincipalAsync(user);

        var rememberMe = request.GetParameter(LoginConsts.RememberMe).ToString();
        if (!rememberMe.IsNullOrWhiteSpace() && bool.TryParse(rememberMe, out var rememberMeValue) && rememberMeValue)
        {
            var claim = new Claim(AbpClaimTypes.RememberMe, true.ToString()).SetDestinations(OpenIddictConstants.Destinations.AccessToken);
            principal.Identities.FirstOrDefault()?.AddClaim(claim);
        }
        var organizationCode = request.GetParameter(LoginConsts.Organization).ToString();
        if (!organizationCode.IsNullOrWhiteSpace())
        {
            var claim = new Claim(HealClaimTypesConsts.OrganizationCode, organizationCode).SetDestinations(OpenIddictConstants.Destinations.AccessToken);
            principal.Identities.FirstOrDefault()?.AddClaim(claim);
        }

        principal.SetScopes(request.GetScopes());
        principal.SetResources(await GetResourcesAsync(request.GetScopes()));

        await OpenIddictClaimsPrincipalManager.HandleAsync(request, principal);

        await IdentitySecurityLogManager.SaveAsync(
            new IdentitySecurityLogContext
            {
                Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
                Action = OpenIddictSecurityLogActionConsts.LoginSucceeded,
                UserName = request.Username,
                ClientId = request.ClientId
            }
        );

        return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// 判断是否需要双因子认证
    /// </summary>
    /// <param name="user">用户信息</param>
    /// <returns>结果</returns>
    protected virtual async Task<bool> IsTfaEnabledAsync(IdentityUser user)
    {
        return UserManager.SupportsUserTwoFactor &&
               await UserManager.GetTwoFactorEnabledAsync(user) &&
               (await UserManager.GetValidTwoFactorProvidersAsync(user)).Count > 0;
    }

    /// <summary>
    /// 登录类型
    /// </summary>
    public enum ChangePasswordType
    {
        /// <summary>
        /// 需要修改密码
        /// </summary>
        ShouldChangePasswordOnNextLogin,

        /// <summary>
        /// 需要定期修改密码
        /// </summary>
        PeriodicallyChangePassword
    }

    /// <summary>
    /// 自定义登录方式
    /// </summary>
    /// <param name="context">context</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> HandleAsync(ExtensionGrantContext context)
    {
        return await HandlePasswordAsync(context.Request);
    }

    /// <summary>
    /// 自定义登录方式名称
    /// </summary>
    public string Name => ApplicationProgramConsts.ApplicationName;
}
