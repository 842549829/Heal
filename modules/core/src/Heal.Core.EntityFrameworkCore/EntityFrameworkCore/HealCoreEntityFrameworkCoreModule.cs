using Heal.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// Core模块
/// </summary>
[DependsOn(
    typeof(HealEntityFrameworkCoreModule)
)]
public class HealCoreEntityFrameworkCoreModule : AbpModule;