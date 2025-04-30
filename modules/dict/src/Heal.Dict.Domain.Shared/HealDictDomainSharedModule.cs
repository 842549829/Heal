using Heal.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Dict.Domain.Shared;

/// <summary>
/// DictDomainShared模块
/// </summary>
[DependsOn(
    typeof(HealDomainSharedModule)
)]
public class HealDictDomainSharedModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HealDictDomainSharedModule>();
        });
    }
}