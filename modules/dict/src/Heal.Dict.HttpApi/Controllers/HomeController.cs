using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Dict.HttpApi.Controllers;

/// <summary>
/// HomeController
/// </summary>
[AllowAnonymous]
public class HomeController : HealDictController
{
    /// <summary>
    /// 启动项
    /// </summary>
    /// <returns>ActionResult</returns>
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}