using Heal.Domain.Shared.Options;
using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using IdentityModel.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using Volo.Abp;

namespace Heal.Net.Application.Bases.Users;

public class AccountAppService(IOptions<AuthServerOptions> authServerOption, IHttpClientFactory httpClientFactory)
    : HealNetAppService, IAccountAppService
{
    private readonly HttpClient _client = httpClientFactory.CreateClient();
    private readonly AuthServerOptions _authServerOption = authServerOption.Value;

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录参数</param>
    /// <returns>登录结果</returns>
    public async Task<LoginResultDto> LoginAsync(LoginInputDto input)
    {
        var disco = await GetDiscoveryDocumentAsync();
        var passwordTokenRequest = new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _authServerOption.ClientId,
            ClientSecret = _authServerOption.ClientSecret,
            UserName = input.UserName,
            Password = input.Password,
            Scope = _authServerOption.Scope,
            GrantType = _authServerOption.GrantType
        };
        if (input.TenantId.HasValue && input.TenantId.Value != Guid.Empty)
        {
            passwordTokenRequest.Headers.Add("__tenant", input.TenantId.Value.ToString());
        }
        var tokenResponse = await _client.RequestPasswordTokenAsync(passwordTokenRequest);
        TokenResponseHandle(tokenResponse);
        var token = CreateLoginResult(tokenResponse);
        return token;
    }

    /// <summary>
    /// 用refresh token获取新的access token
    /// </summary>
    /// <param name="input">refresh token</param>
    /// <returns>刷新结果</returns>
    public async Task<LoginResultDto> RefreshAsync(RefreshTokenInputDto input)
    {
        var disco = await GetDiscoveryDocumentAsync();
        var tokenResponse = await _client.RequestRefreshTokenAsync(new RefreshTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _authServerOption.ClientId,
            ClientSecret = _authServerOption.ClientSecret,
            RefreshToken = input.RefreshToken
        });
        TokenResponseHandle(tokenResponse);
        var token = CreateLoginResult(tokenResponse);
        return token;
    }

    private static LoginResultDto CreateLoginResult(TokenResponse tokenResponse)
    {
        var token = new LoginResultDto
        {
            AccessToken = tokenResponse.AccessToken!,
            RefreshToken = tokenResponse.RefreshToken!,
            TokenType = tokenResponse.TokenType!,
            ExpiresIn = tokenResponse.ExpiresIn
        };
        return token;
    }

    private async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentAsync()
    {
        var discoveryDocumentRequest = new DiscoveryDocumentRequest
        {
            Address = _authServerOption.Authority,
            Policy =
            {
                RequireHttps = _authServerOption.RequireHttpsMetadata
            }
        };
        var disco = await _client.GetDiscoveryDocumentAsync(discoveryDocumentRequest);
        if (disco.IsError)
        {
            DiscoveryDocumentResponseHandle(disco);
        }

        return disco;
    }

    private void DiscoveryDocumentResponseHandle(ProtocolResponse disco)
    {
        var msg = disco.Error != null
            ? $"用户连接到注册中心出错，详情{disco.Error}"
            : $"用户连接到注册中心出错，错误码{disco.HttpStatusCode}，详情{disco.Json}";
        Logger.LogError(msg);
        if (disco.Exception != null)
        {
            Logger.LogError(disco.Exception, "连接到注册中心出错");
        }

        throw new UserFriendlyException(message: "连接到注册中心出错");
    }

    private void TokenResponseHandle(TokenResponse tokenResponse)
    {
        if (!tokenResponse.IsError)
        {
            return;
        }

        Logger.LogError("登录获取token出错，错误信息{@tokenResponse}", tokenResponse);

        if (tokenResponse.Exception != null)
        {
            Logger.LogError(tokenResponse.Exception, "登录到注册中心出错");
        }

        if (tokenResponse.HttpResponse == null)
        {
            throw new UserFriendlyException("登录请求异常");
        }

        if (tokenResponse.HttpResponse.StatusCode == HttpStatusCode.InternalServerError ||
            tokenResponse.Error == "Internal Server Error")
        {
            throw new UserFriendlyException("认证中心服务器异常");
        }

        switch (tokenResponse.Error)
        {
            case "invalid_grant":
                throw new UserFriendlyException("登录帐号或密码错误");
            case "invalid_request":
                throw new UserFriendlyException("登录请求异常");
            default:
                Logger.LogError("登录获取token出错，错误信息{@tokenResponse}", tokenResponse);
                throw new UserFriendlyException("登录系统错误");
        }
    }
}