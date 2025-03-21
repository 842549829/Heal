using Heal.Domain;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Heal.EntityFrameworkCore;


[DependsOn(
    typeof(HealDomainModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpIdentityEntityFrameworkCoreModule)
)]
public class HealEntityFrameworkCoreModule : AbpModule;