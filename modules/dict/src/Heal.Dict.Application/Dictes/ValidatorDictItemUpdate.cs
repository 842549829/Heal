using FluentValidation;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 验证器
/// </summary>
public class ValidatorDictItemUpdate : ValidatorDictItem<DictItemUpdateDto>
{
    /// <summary>
    /// 验证器
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public ValidatorDictItemUpdate(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        SetRules();
    }

    /// <summary>
    /// 设置验证规则
    /// </summary>
    private void SetRules()
    {
        // TODO 多语言配置
        RuleFor(x => x.ConcurrencyStamp)
            .Length(32)
            .WithMessage("字典迸发标记输入错误 长度32位");
    }
}