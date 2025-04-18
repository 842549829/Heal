using Heal.Domain.Shared.Exceptions;
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

    /// <summary>
    /// 验证字段
    /// </summary>
    /// <param name="ex">领域层异常</param>
    /// <returns>结果</returns>
    private string FormatLocalizedMessage(DomainValidationException ex)
    {
        // 获取本地化消息模板
        var messageTemplate = L[ex.Key];

        // 如果有参数，则格式化消息
        return ex.Arguments.Any()
            ? string.Format(messageTemplate, ex.Arguments)
            : messageTemplate;
    }
}