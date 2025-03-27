using Heal.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Heal.Application;

/// <summary>
/// HealApplicationModule
/// </summary>
[DependsOn(
    typeof(HealDomainModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpIdentityApplicationModule)
)]
public class HealApplicationModule : AbpModule;