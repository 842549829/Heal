using Heal.Dict.Domain.Shared;
using Heal.Domain;
using Volo.Abp.Modularity;

namespace Heal.Dict.Domain;

/// <summary>
/// CoreDomain模块
/// </summary>
[DependsOn(
    typeof(HealDictDomainSharedModule),
    typeof(HealDomainModule)
)]
public class HealDictDomainModule : AbpModule;