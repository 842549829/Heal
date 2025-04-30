using Duende.IdentityModel;
using Duende.IdentityModel.Client;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Options;
using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
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
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>登录结果</returns>
    public async Task<LoginResultDto> LoginAsync(LoginInputDto input, CancellationToken cancellationToken = default)
    {
        var disco = await GetDiscoveryDocumentAsync();
        var request = new TokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _authServerOption.ClientId,
            ClientSecret = _authServerOption.ClientSecret,
            GrantType =  _authServerOption.GrantType
        };
        if (input.TenantId.HasValue && input.TenantId.Value != Guid.Empty)
        {
            request.Headers.Add(LoginConsts.Tenant, input.TenantId.Value.ToString());
        }
        //if (!input.OrganizationCode.IsNullOrWhiteSpace())
        //{
        //    request.Parameters.Add(LoginConsts.Organization, input.OrganizationCode);
        //}
        if (input.Remember.HasValue)
        {
            request.Parameters.Add(LoginConsts.RememberMe, input.Remember.Value.ToString());
        }

        request.Parameters.AddRequired(OidcConstants.TokenRequest.GrantType, _authServerOption.GrantType);
        request.Parameters.AddRequired(OidcConstants.TokenRequest.UserName, input.UserName);
        request.Parameters.AddRequired(OidcConstants.TokenRequest.Password, input.Password, allowEmptyValue: true);
        request.Parameters.AddOptional(OidcConstants.TokenRequest.Scope, _authServerOption.Scope);

      
        var tokenResponse = await _client.RequestTokenAsync(request, cancellationToken: cancellationToken);
        TokenResponseHandle(tokenResponse);
        var token = CreateLoginResult(tokenResponse);
        return token;
    }

    /// <summary>
    /// 用refresh token获取新的access token
    /// </summary>
    /// <param name="input">refresh token</param>
    /// <param name="cancellationToken">, CancellationToken cancellationToken = default</param>
    /// <returns>刷新结果</returns>
    public async Task<LoginResultDto> RefreshAsync(RefreshTokenInputDto input, CancellationToken cancellationToken = default)
    {
        var disco = await GetDiscoveryDocumentAsync();
        var tokenResponse = await _client.RequestRefreshTokenAsync(new RefreshTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = _authServerOption.ClientId,
            ClientSecret = _authServerOption.ClientSecret,
            RefreshToken = input.RefreshToken
        }, cancellationToken);
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