using Heal.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Heal.HttpApi.Controllers;

/// <summary>
///Heal基础控制器
/// </summary>
public abstract class HealController : AbpControllerBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    protected HealController()
    {
        LocalizationResource = typeof(HealResource);
    }
}