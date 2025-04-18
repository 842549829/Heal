using FluentValidation;
using Heal.Application;
using Heal.Domain.Shared.Constants;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Microsoft.Extensions.Localization;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// 院区创建验证器
/// </summary>
public class CampusCreateValidator : ValidationBase<CampusCreateDto>
{
    /// <summary>
    /// 院区创建验证器
    /// </summary>
    private readonly IStringLocalizer _localizer;

    /// <summary>
    /// 院区创建验证器
    /// </summary>
    /// <param name="localizer">本地化接口</param>
    public CampusCreateValidator(IStringLocalizer localizer)
    {
        _localizer = localizer;

        // 验证名称
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConsts.Name))
            .Length(1, NameConsts.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Name, 1, NameConsts.MaxLength));

        // 验证编码
        RuleFor(x => x.OrganizationCode)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConsts.OrganizationCode))
            .Length(1, CodeConsts.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.OrganizationCode, 1, CodeConsts.MaxLength));

        // 验证描述
        RuleFor(x => x.Describe)
            .Length(1, DescribeConsts.MaxLength)
            .When(x => !string.IsNullOrEmpty(x.Describe)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Describe, 1, CodeConsts.MaxLength));

        // 验证简称
        RuleFor(x => x.ShortName)
            .Length(1, CampusConsts.MaxShortNameLength)
            .When(x => !string.IsNullOrEmpty(x.ShortName))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.ShortName, 1, CampusConsts.MaxShortNameLength));
    }

    /// <summary>
    /// 安全地格式化本地化字符串。
    /// </summary>
    /// <param name="key">本地化键。</param>
    /// <param name="args">格式化参数。</param>
    /// <returns>格式化后的字符串。</returns>
    protected string FieldLengthFormatLocalized(
        string key,
        params object[] args)
    {
        return FieldLengthFormatLocalized(_localizer, key, args);
    }

    /// <summary>
    /// 字段非空安全地格式化本地化字符串
    /// </summary>
    /// <param name="key">本地化键</param>
    /// <returns>格式化后的字符串</returns>
    public string FieldIsRequiredFormatLocalized(string key)
    {
        return FieldIsRequiredFormatLocalized(_localizer, key);
    }
}