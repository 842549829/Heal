using Heal.HttpApi.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace Heal.Dict.HttpApi.Controllers;

/// <summary>
/// HeaNet基础控制器
/// </summary>
[Authorize]
public abstract class HealDictController : HealController;