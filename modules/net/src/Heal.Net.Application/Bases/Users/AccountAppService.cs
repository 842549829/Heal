using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;

namespace Heal.Net.Application.Bases.Users;

public class AccountAppService: HealNetAppService, IAccountAppService
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录参数</param>
    /// <returns>登录结果</returns>
    public Task<LoginResultDto> LoginAsync(LoginInputDto input)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 用refresh token获取新的access token
    /// </summary>
    /// <param name="input">refresh token</param>
    /// <returns>刷新结果</returns>
    public Task<LoginResultDto> RefreshAsync(RefreshTokenInputDto input)
    {
        throw new NotImplementedException();
    }
}