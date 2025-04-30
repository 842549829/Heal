using Heal.Dict.Application.Contracts;
using Heal.HttpApi;
using Volo.Abp.Modularity;

namespace Heal.Dict.HttpApi;

/// <summary>
/// HealDictHttpApiModule
/// </summary>
[DependsOn(
    typeof(HealHttpApiModule),
    typeof(HealDictApplicationContractsModule)
)]
public class HealDictHttpApiModule : AbpModule;