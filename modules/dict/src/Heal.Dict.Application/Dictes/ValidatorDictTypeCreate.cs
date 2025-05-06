using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 字典类型验证器
/// </summary>
public class ValidatorDictTypeCreate : ValidatorDictType<DictTypeCreateDto>
{
    /// <summary>
    /// 验证器
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public ValidatorDictTypeCreate(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
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