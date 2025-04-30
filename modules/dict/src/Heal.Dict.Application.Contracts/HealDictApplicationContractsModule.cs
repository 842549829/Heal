using Heal.Application.Contracts;
using Heal.Dict.Domain.Shared;
using Volo.Abp.Modularity;

namespace Heal.Dict.Application.Contracts;

/// <summary>
/// 字典Contract模块
/// </summary>
[DependsOn(
    typeof(HealApplicationContractsModule),
    typeof(HealDictDomainSharedModule)
)]
public class HealDictApplicationContractsModule : AbpModule;