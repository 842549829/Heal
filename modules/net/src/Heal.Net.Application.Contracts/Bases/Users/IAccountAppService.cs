using Heal.Net.Application.Contracts.Bases.Users.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users;

public interface IAccountAppService : IHealNetApplicationService
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录参数</param>
    /// <returns>登录结果</returns>
    public Task<LoginResultDto> LoginAsync(LoginInputDto input);

    /// <summary>
    /// 用refresh token获取新的access token
    /// </summary>
    /// <param name="input">refresh token</param>
    /// <returns>刷新结果</returns>
    public Task<LoginResultDto> RefreshAsync(RefreshTokenInputDto input);
}