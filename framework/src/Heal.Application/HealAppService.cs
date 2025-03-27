using Heal.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Heal.Application;

/// <summary>
/// HealAppService 抽象服务层
/// </summary>
public abstract class HealAppService : ApplicationService
{
    /// <summary>
    /// 构造函数
    /// </summary>
    protected HealAppService()
    {
        // 设置本地化资源
        LocalizationResource = typeof(HealResource);
    }
}