using FluentValidation;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Extensions;
using Microsoft.Extensions.Localization;

namespace Heal.Application;

/// <summary>
/// 验证基类
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class ValidationBase<T> : AbstractValidator<T>
{
    /// <summary>
    /// 字段长度安全地格式化本地化字符串。
    /// </summary>
    /// <param name="localizer">IStringLocalizer 实例。</param>
    /// <param name="key">本地化键。</param>
    /// <param name="args">格式化参数。</param>
    /// <returns>格式化后的字符串。</returns>
    protected static string FieldLengthFormatLocalized(
        IStringLocalizer localizer,
        string key,
        params object[] args)
    {
        const string defaultFormat = "The length of field '{0}' is not within the allowed range. The allowed range is {1}-{2}.";

        // 获取本地化值
        var localizedValue = localizer[LocalizedTextsConsts.FieldLengthValidation].Value;

        // 如果本地化值为空或无效，则使用默认值
        var format = string.IsNullOrEmpty(localizedValue) || localizedValue == LocalizedTextsConsts.FieldLengthValidation ? defaultFormat : localizedValue;
        var keyValue = localizer[key].Value;

        // 格式化字符串
        return string.Format(format, keyValue, args);
    }

    /// <summary>
    /// 字段非空安全地格式化本地化字符串
    /// </summary>
    /// <param name="localizer">IStringLocalizer 实例。</param>
    /// <param name="key">本地化键</param>
    /// <returns>格式化后的字符串</returns>
    protected static string FieldIsRequiredFormatLocalized(
        IStringLocalizer localizer,
        string key)
    {
        const string defaultFormat = "The field '{0}' is required.";

        // 获取本地化值
        var localizedValue = localizer[LocalizedTextsConsts.FieldIsRequired].Value;

        // 如果本地化值为空或无效，则使用默认值
        var format = string.IsNullOrEmpty(localizedValue) || localizedValue == LocalizedTextsConsts.FieldIsRequired ? defaultFormat : localizedValue;
        var keyValue = localizer[key].Value;

        // 格式化字符串
        return string.Format(format, keyValue);
    }

    /// <summary>
    /// 身份证验证
    /// </summary>
    /// <param name="idCard">idCard</param>
    /// <returns>结果</returns>
    protected bool ValidationIdCard(string idCard)
    {
        return IdCardExtension.IsValidIdCard(idCard);
    }

    /// <summary>
    /// 手机/座机号码验证
    /// </summary>
    /// <param name="phone">号码</param>
    /// <returns>结果</returns>
    protected static bool ValidationTelephoneOrMobile(string phone)
    {
        return PhoneExtension.IsValidationTelephoneOrMobile(phone);
    }

    /// <summary>
    /// 验证手机号是否合法
    /// </summary>
    /// <param name="phone">手机号</param>
    /// <returns>结果</returns>
    protected static bool ValidPhoneNumber(string phone)
    {
        return PhoneExtension.IsValidPhoneNumber(phone);
    }

    /// <summary>
    /// 座机验证
    /// </summary>
    /// <param name="phone">座机</param>
    /// <returns>结果</returns>
    protected static bool ValidationTelephone(string phone)
    {
        return PhoneExtension.IsValidationTelephone(phone);
    }

    /// <summary>
    /// 邮箱验证
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>结果</returns>
    protected static bool ValidationEmail(string email)
    {
        return EmailExtension.IsValidEmail(email);
    }
}