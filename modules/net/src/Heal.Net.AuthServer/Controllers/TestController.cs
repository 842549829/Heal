using System.Globalization;
using Heal.Domain.Shared.Localization;
using Heal.Net.AuthServer.HttpApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Volo.Abp.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Net.AuthServer.Controllers;

[Route("api/test")]
public class TestController : HealNetAuthServerController
{
    private readonly IStringLocalizer<HealResource> _localizer;
    private readonly IVirtualFileProvider _virtualFileProvider;

    public TestController(
        IStringLocalizer<HealResource> localizer,
        IVirtualFileProvider virtualFileProvider)
    {
        _localizer = localizer;
        _virtualFileProvider = virtualFileProvider;
    }

    public record LocalizationTestResult(
        string CurrentCulture,
        string CurrentUICulture,
        string AppName,
        string Welcome,
        IEnumerable<string> AvailableResources,
        IEnumerable<string> VirtualFiles
    );

    [HttpGet]
    public ActionResult<LocalizationTestResult> Get()
    {
        var assembly = typeof(HealResource).Assembly;
        var resourceNames = assembly.GetManifestResourceNames();
        
        // 修改虚拟文件路径检查
        var files = _virtualFileProvider
            .GetDirectoryContents("Heal/Domain/Shared/Localization/Heal")
            .Select(file => $"{file.Name}: {file.Exists}")
            .ToList();
        
        // 强制设置当前文化
        Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-Hans");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-Hans");

        return Ok(new LocalizationTestResult(
            CultureInfo.CurrentCulture.Name,
            CultureInfo.CurrentUICulture.Name,
            _localizer["AppName"],
            _localizer["Welcome"],
            _localizer.GetAllStrings(true).Select(s => $"{s.Name}: {s.Value}"),
            resourceNames
        ));
    }
}
