using Heal.Application.Contracts;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Heal.HttpApi.Client;

/// <summary>
/// HealHttpApiClientModule
/// </summary>
[DependsOn(
    typeof(HealApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiClientModule)
)]
public class HealHttpApiClientModule : AbpModule;