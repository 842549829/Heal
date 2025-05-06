using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 创建字典项验证器
/// </summary>
public class ValidatorDictItemCreate : ValidatorDictItem<DictItemCreateDto>
{
    /// <summary>
    /// 验证器
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public ValidatorDictItemCreate(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        SetRules();
    }

    /// <summary>
    /// 设置验证规则
    /// </summary>
    private void SetRules()
    {
    }
}