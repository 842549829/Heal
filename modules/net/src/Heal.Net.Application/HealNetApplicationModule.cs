using Heal.Application;
using Heal.Net.Application.Contracts;
using Heal.Net.Domain;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Heal.Net.Application;

[DependsOn(
    typeof(HealNetDomainModule),
    typeof(HealApplicationModule),
    typeof(HealNetApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class HealNetApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HealNetApplicationModule>();
        });
    }
}
