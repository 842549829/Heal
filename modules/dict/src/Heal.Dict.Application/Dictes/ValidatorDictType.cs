using FluentValidation;
using Heal.Application;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 字典类型验证
/// </summary>
/// <typeparam name="T">T</typeparam>
public class ValidatorDictType<T> : ValidationBase<T>
    where T : DictTypeCreateOrUpdateDtoBase
{
    /// <summary>
    /// 验证器
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public ValidatorDictType(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        SetRules();
    }

    /// <summary>
    /// 设置验证规则
    /// </summary>
    private void SetRules()
    {
        // TODO 多语言配置
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("字典分类名称不能为空")
            .Length(1, 30)
            .WithMessage("字典分类名称输入错误 长度1-30位");

        RuleFor(x => x.Sort)
            .Must(ValidationSortNo)
            .WithMessage("排序号输入错误 必须是正数");

        RuleFor(x => x.Describe)
            .NotNull()
            .WithMessage("字典分类描述不能为空")
            .Length(1, 30)
            .WithMessage("字典分类描述输入错误 长度1-150位");
    }
}