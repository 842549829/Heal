using Heal.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Domain.Shared;

/// <summary>
/// HealDomainSharedModule
/// </summary>
[DependsOn(
    typeof(AbpPermissionManagementDomainSharedModule)
)]
public class HealDomainSharedModule : AbpModule
{
    /// <summary>
    /// PreConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        HealGlobalFeatureConfigurator.Configure();
        HealModuleExtensionConfigurator.Configure();
    }

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HealDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<HealResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Heal");

            options.DefaultResourceType = typeof(HealResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Heal", typeof(HealResource));
        });
    }
}