using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

[Route("api/basics/accounts")]
[ApiController]
[AllowAnonymous]
public class AccountController(IAccountAppService accountAppService) : HealNetController
{
    [HttpPost("login")]
    public async Task<ActionResult<LoginResultDto>> LoginAsync(LoginInputDto input)
    {
        return await accountAppService.LoginAsync(input);
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<LoginResultDto>> RefreshAsync(RefreshTokenInputDto input)
    {
        return await accountAppService.RefreshAsync(input);
    }
}