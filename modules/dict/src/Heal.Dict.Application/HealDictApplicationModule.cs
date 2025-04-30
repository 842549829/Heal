using Heal.Application;
using Heal.Dict.Domain;
using Volo.Abp.Modularity;

namespace Heal.Dict.Application;

/// <summary>
/// 字典应用层模块
/// </summary>
[DependsOn(
    typeof(HealDictDomainModule),
    typeof(HealApplicationModule)
)]
public class HealDictApplicationModule : AbpModule;