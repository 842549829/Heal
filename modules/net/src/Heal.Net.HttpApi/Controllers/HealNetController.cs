using Heal.HttpApi.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Heal.Net.HttpApi.Controllers;

/// <summary>
/// HeaNet基础控制器
/// </summary>
//[Authorize]
[AllowAnonymous]
public abstract class HealNetController : HealController;