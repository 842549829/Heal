using Heal.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Heal.Domain;


[DependsOn(
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(HealDomainSharedModule)
)]
public class HealDomainModule : AbpModule;