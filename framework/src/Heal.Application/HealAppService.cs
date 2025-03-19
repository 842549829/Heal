using Heal.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Heal.Application;

/// <summary>
/// HealAppService
/// </summary>
public abstract class HealAppService : ApplicationService
{
    /// <summary>
    /// 构造函数
    /// </summary>
    protected HealAppService()
    {
        LocalizationResource = typeof(HealResource);
    }
}