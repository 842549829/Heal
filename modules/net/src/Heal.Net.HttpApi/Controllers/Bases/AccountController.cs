using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

[Route("api/basics/accounts")]
[ApiController]
[AllowAnonymous]
public class AccountController : HealNetController
{

}