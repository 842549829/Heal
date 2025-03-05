using Heal.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Heal.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HealEntityFrameworkCoreModule),
    typeof(HealApplicationContractsModule)
)]
public class HealDbMigratorModule : AbpModule
{
}
