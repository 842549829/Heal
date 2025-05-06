using Heal.Dict.Application.Contracts;
using Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Heal.Dict.DbMigrator;

/// <summary>
/// HealNetDbMigratorModule
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HealDictEntityFrameworkCoreModule),
    typeof(HealDictApplicationContractsModule)
)]
public class HealDictDbMigratorModule : AbpModule;
