using System.Security.Claims;
using System.Security.Principal;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;

namespace Heal.Net.AuthServer.ExtensionGrantTypes;

/// <summary>
/// DataPermissionClaimsPrincipalContributor
/// </summary>
public class DataPermissionClaimsPrincipalContributor : IAbpClaimsPrincipalContributor, ITransientDependency
{
    /// <summary>
    /// ContributeAsync
    /// </summary>
    /// <param name="context">context</param>
    /// <returns>Task</returns>
    public async Task ContributeAsync(AbpClaimsPrincipalContributorContext context)
    {
        var identity = context.ClaimsPrincipal.Identities.FirstOrDefault();
        var userId = identity?.FindUserId();
        var userManager = context.ServiceProvider.GetRequiredService<IdentityUserManager>();
        var user = await userManager.GetUserAsync(context.ClaimsPrincipal);
        if (user != null && identity != null && userId.HasValue)
        {
            // TODO 获取用户数据权限待实现
            identity.AddClaim(new Claim("data_permission", "socialSecurityNumber"));
            identity.AddClaim(new Claim("data_permission1", "socialSecurityNumber1"));
            identity.AddClaim(new Claim("socialSecurityNumber", "socialSecurityNumber1"));
        }
    }
}