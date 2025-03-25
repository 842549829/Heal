using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers;

[AllowAnonymous]
public class HomeController : HealNetController
{
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
}