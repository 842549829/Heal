using Heal.Domain.Shared.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Volo.Abp.Localization;

namespace Heal.Domain;

/// <summary>
/// 基础领域服务
/// </summary>
public abstract class HealDomainManager : DomainService
{
    /// <summary>
    /// 获取本地化资源
    /// </summary>
    private IStringLocalizer? _localizer;

    /// <summary>
    /// 本地化资源
    /// </summary>
    private Type? _localizationResource = typeof(HealResource);

    /// <summary>
    /// 获取本地化资源
    /// </summary>
    protected IStringLocalizerFactory StringLocalizerFactory => LazyServiceProvider.LazyGetRequiredService<IStringLocalizerFactory>();

    /// <summary>
    /// 本地化资源
    /// </summary>
    protected IStringLocalizer L => _localizer ??= CreateLocalizer();

    /// <summary>
    /// 本地化资源
    /// </summary>
    protected Type? LocalizationResource
    {
        get => _localizationResource;
        set
        {
            _localizationResource = value;
            _localizer = null;
        }
    }

    /// <summary>
    /// 创建本地化资源
    /// </summary>
    /// <returns>本地化资源</returns>
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
}