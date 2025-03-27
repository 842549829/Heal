using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 文件控制器
/// </summary>
[Route("api/basics/files")]
[ApiController]
public class FileController : HealNetController
{
    // 测试是否登录
    [HttpGet("test")]
    public ActionResult<string> Test()
    {
        return "test";
    }
}