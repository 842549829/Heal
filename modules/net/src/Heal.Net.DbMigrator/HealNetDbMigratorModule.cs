using Heal.Net.Application.Contracts;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Heal.Net.DbMigrator;

/// <summary>
/// HealNetDbMigratorModule
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HealNetEntityFrameworkCoreModule),
    typeof(HealNetApplicationContractsModule)
)]
public class HealNetDbMigratorModule : AbpModule;
