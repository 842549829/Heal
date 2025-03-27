using Heal.Domain.Shared.Localization;
using Heal.Net.AuthServer.HttpApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Net.AuthServer.Controllers;

/// <summary>
/// 测试控制器
/// </summary>
[Route("api/test")]
public class TestController(
    IStringLocalizer<HealResource> localizer,
    IVirtualFileProvider virtualFileProvider)
    : HealNetAuthServerController
{
    /// <summary>
    /// 本地化测试记录
    /// </summary>
    /// <param name="CurrentCulture">CurrentCulture</param>
    /// <param name="CurrentUICulture">CurrentUICulture</param>
    /// <param name="AppName">AppName</param>
    /// <param name="Welcome">Welcome</param>
    /// <param name="AvailableResources">AvailableResources</param>
    /// <param name="VirtualFiles">VirtualFiles</param>
    public record LocalizationTestResult(
        string CurrentCulture,
        string CurrentUICulture,
        string AppName,
        string Welcome,
        IEnumerable<string> AvailableResources,
        IEnumerable<string> VirtualFiles
    );

    /// <summary>
    /// 本地化测试
    /// </summary>
    /// <returns>返回测试内容</returns>
    [HttpGet]
    public ActionResult<LocalizationTestResult> Get()
    {
        var assembly = typeof(HealResource).Assembly;
        var resourceNames = assembly.GetManifestResourceNames();
        
        // 修改虚拟文件路径检查
        var files = virtualFileProvider
            .GetDirectoryContents("Heal/Domain/Shared/Localization/Heal")
            .Select(file => $"{file.Name}: {file.Exists}")
            .ToList();
        
        // 强制设置当前文化
        Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-Hans");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-Hans");

        return Ok(new LocalizationTestResult(
            CultureInfo.CurrentCulture.Name,
            CultureInfo.CurrentUICulture.Name,
            localizer["AppName"],
            localizer["Welcome"],
            localizer.GetAllStrings(true).Select(s => $"{s.Name}: {s.Value}"),
            resourceNames
        ));
    }
}
