using Heal.Domain.Shared.Localization;
using Heal.HttpApi;
using Heal.Net.Application.Contracts;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Heal.Net.AuthServer.HttpApi;

/// <summary>
/// HealNetAuthServerHttpApiModule
/// </summary>
[DependsOn(
     typeof(HealHttpApiModule),
    typeof(HealNetApplicationContractsModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule)
    )]
public class HealNetAuthServerHttpApiModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 配置本地化
        ConfigureLocalization();
    }

    /// <summary>
    /// ConfigureLocalization
    /// </summary>
    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<HealResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
