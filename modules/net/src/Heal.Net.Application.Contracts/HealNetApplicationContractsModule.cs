using Heal.Application.Contracts;
using Heal.Net.Domain.Shared;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Heal.Net.Application.Contracts;

[DependsOn(
    typeof(HealNetDomainSharedModule),
    typeof(HealApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpTenantManagementApplicationContractsModule)
)]
public class HealNetApplicationContractsModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        HealNetDtoExtensions.Configure();
    }
}
