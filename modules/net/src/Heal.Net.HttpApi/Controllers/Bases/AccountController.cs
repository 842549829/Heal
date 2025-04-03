using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 账户管理控制器
/// </summary>
/// <param name="accountAppService">账号服务接口</param>
[Route("api/net/basics/accounts")]
[ApiController]
[AllowAnonymous]
public class AccountController(IAccountAppService accountAppService) : HealNetController
{
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="input">登录信息</param>
    /// <returns>登录结果</returns>
    [HttpPost("login")]
    public async Task<ActionResult<LoginResultDto>> LoginAsync(LoginInputDto input)
    {
        return await accountAppService.LoginAsync(input);
    }

    /// <summary>
    /// 刷新token
    /// </summary>
    /// <param name="input">刷新token</param>
    /// <returns>结果</returns>
    [HttpPost("refresh")]
    public async Task<ActionResult<LoginResultDto>> RefreshAsync(RefreshTokenInputDto input)
    {
        return await accountAppService.RefreshAsync(input);
    }
}