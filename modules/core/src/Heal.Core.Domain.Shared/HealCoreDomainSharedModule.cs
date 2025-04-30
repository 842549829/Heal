using Heal.Domain.Shared;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Core.Domain.Shared;

/// <summary>
/// CoreDomainShared模块
/// </summary>
[DependsOn(
    typeof(HealDomainSharedModule)
)]
public class HealCoreDomainSharedModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HealCoreDomainSharedModule>();
        });
    }
}