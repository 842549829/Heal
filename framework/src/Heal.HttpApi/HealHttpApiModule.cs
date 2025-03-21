using Heal.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;

namespace Heal.HttpApi;

[DependsOn(
    typeof(HealApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule)
)]
public class HealHttpApiModule : AbpModule;