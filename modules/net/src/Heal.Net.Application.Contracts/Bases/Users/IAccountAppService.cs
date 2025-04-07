using Heal.Net.Application.Contracts.Bases.Users.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users;

/// <summary>
/// 账号服务接口
/// </summary>
public interface IAccountAppService : IHealNetApplicationService
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录参数</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>登录结果</returns>
    public Task<LoginResultDto> LoginAsync(LoginInputDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 用refresh token获取新的access token
    /// </summary>
    /// <param name="input">refresh token</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>刷新结果</returns>
    public Task<LoginResultDto> RefreshAsync(RefreshTokenInputDto input, CancellationToken cancellationToken = default);
}