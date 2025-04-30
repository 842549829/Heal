using Heal.Core.Domain.Shared;
using Heal.Domain;
using Volo.Abp.Modularity;

namespace Heal.Core.Domain;

/// <summary>
/// CoreDomain模块
/// </summary>
[DependsOn(
    typeof(HealCoreDomainSharedModule),
    typeof(HealDomainModule)
)]
public class HealCoreDomainModule : AbpModule;