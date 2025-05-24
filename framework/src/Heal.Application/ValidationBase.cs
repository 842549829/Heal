using FluentValidation;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Extensions;
using Heal.Domain.Shared.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Localization;

namespace Heal.Application;

/// <summary>
/// 验证基类
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class ValidationBase<T> : AbstractValidator<T>
{
    public ValidationBase(IAbpLazyServiceProvider lazyServiceProvider)
    {
        LazyServiceProvider = lazyServiceProvider;
        LocalizationResource = typeof(HealResource);
    }

    public IAbpLazyServiceProvider LazyServiceProvider { get; set; }

    protected IStringLocalizerFactory StringLocalizerFactory => LazyServiceProvider.LazyGetRequiredService<IStringLocalizerFactory>();

    protected IStringLocalizer L
    {
        get
        {
            if (_localizer == null)
            {
                _localizer = CreateLocalizer();
            }

            return _localizer;
        }
    }
    private IStringLocalizer? _localizer;

    protected Type? LocalizationResource
    {
        get => _localizationResource;
        set
        {
            _localizationResource = value;
            _localizer = null;
        }
    }
    private Type? _localizationResource = typeof(DefaultResource);

    protected virtual IStringLocalizer CreateLocalizer()
    {
        if (LocalizationResource != null)
        {
            return StringLocalizerFactory.Create(LocalizationResource);
        }

        var localizer = StringLocalizerFactory.CreateDefaultOrNull();
        if (localizer == null)
        {
            throw new AbpException($"Set {nameof(LocalizationResource)} or define the default localization resource type (by configuring the {nameof(AbpLocalizationOptions)}.{nameof(AbpLocalizationOptions.DefaultResourceType)}) to be able to use the {nameof(L)} object!");
        }

        return localizer;
    }

    /// <summary>
    /// 字段长度安全地格式化本地化字符串。
    /// </summary>
    /// <param name="key">本地化键。</param>
    /// <param name="start">开始</param>
    /// <param name="end">结束</param>
    /// <returns>格式化后的字符串。</returns>
    protected string FieldLengthFormatLocalized(
        string key,
        int start,
        int end)
    {
        const string defaultFormat = "The length of field '{0}' is not within the allowed range. The allowed range is {1}-{2}.";

        // 获取本地化值
        var localizedValue = L[LocalizedTextsConstants.FieldLengthValidation].Value;

        // 如果本地化值为空或无效，则使用默认值
        var format = string.IsNullOrEmpty(localizedValue) || localizedValue == LocalizedTextsConstants.FieldLengthValidation ? defaultFormat : localizedValue;
        var keyValue = L[key].Value;

        // 格式化字符串
        return string.Format(format, keyValue, start, end);
    }

    /// <summary>
    /// 字段非空安全地格式化本地化字符串
    /// </summary>
    /// <param name="key">本地化键</param>
    /// <returns>格式化后的字符串</returns>
    protected string FieldIsRequiredFormatLocalized(
        string key)
    {
        const string defaultFormat = "The field '{0}' is required.";

        // 获取本地化值
        var localizedValue = L[LocalizedTextsConstants.FieldIsRequired].Value;

        // 如果本地化值为空或无效，则使用默认值
        var format = string.IsNullOrEmpty(localizedValue) || localizedValue == LocalizedTextsConstants.FieldIsRequired ? defaultFormat : localizedValue;
        var keyValue = L[key].Value;

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

    /// <summary>
    /// 排序号验证
    /// </summary>
    /// <returns>结果</returns>
    protected static bool ValidationSortNo(int sortNo)
    {
        return sortNo >= 0;
    }
}