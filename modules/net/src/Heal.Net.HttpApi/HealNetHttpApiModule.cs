using Heal.HttpApi;
using Heal.Net.Application.Contracts;
using Volo.Abp.Modularity;

namespace Heal.Net.HttpApi;

[DependsOn(
    typeof(HealHttpApiModule),
    typeof(HealNetApplicationContractsModule)
    )]
public class HealNetHttpApiModule : AbpModule;