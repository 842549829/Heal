using Heal.Domain.Shared;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Net.Domain.Shared;

/// <summary>
/// HealNetDomainSharedModule
/// </summary>
[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(BlobStoringDatabaseDomainSharedModule),
    typeof(HealDomainSharedModule)
    )]
public class HealNetDomainSharedModule : AbpModule
{
    /// <summary>
    /// PreConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        HealNetGlobalFeatureConfigurator.Configure();
        HealNetModuleExtensionConfigurator.Configure();
    }

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HealNetDomainSharedModule>();
        });
    }
}