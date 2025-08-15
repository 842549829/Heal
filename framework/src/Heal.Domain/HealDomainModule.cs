using Heal.Domain.Shared;
using Heal.Domain.Shared.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Heal.Domain;

/// <summary>
/// HealDomainModule
/// </summary>
[DependsOn(
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(HealDomainSharedModule)
)]
public class HealDomainModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            // 启用多租户
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });

        // 配置本地化
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("ar", "ar", "العربية"));
            options.Languages.Add(new LanguageInfo("cs", "cs", "Čeština"));
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("en-GB", "en-GB", "English (UK)"));
            options.Languages.Add(new LanguageInfo("hu", "hu", "Magyar"));
            options.Languages.Add(new LanguageInfo("fi", "fi", "Finnish"));
            options.Languages.Add(new LanguageInfo("fr", "fr", "Français"));
            options.Languages.Add(new LanguageInfo("hi", "hi", "Hindi"));
            options.Languages.Add(new LanguageInfo("it", "it", "Italiano"));
            options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
            options.Languages.Add(new LanguageInfo("ru", "ru", "Русский"));
            options.Languages.Add(new LanguageInfo("sk", "sk", "Slovak"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            options.Languages.Add(new LanguageInfo("zh-Hant", "zh-Hant", "繁體中文"));
            options.Languages.Add(new LanguageInfo("de-DE", "de-DE", "Deutsch"));
            options.Languages.Add(new LanguageInfo("es", "es", "Español"));
            options.Languages.Add(new LanguageInfo("sv", "sv", "Svenska"));
        });

        Configure<PermissionManagementOptions>(options =>
        {
            // 启用动态权限 启用后不用再去配置了只需要在数据库配置即可
            options.IsDynamicPermissionStoreEnabled = true;

            // 自动同步静态权限到数据库 (首次初始化数据后则关闭静态同步后期则直接维护数据库的权限)
            options.SaveStaticPermissionsToDatabase = false;
        });
    }
}