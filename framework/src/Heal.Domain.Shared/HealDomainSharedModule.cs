using Heal.Domain.Shared.Localization;
using Volo.Abp.Identity;
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
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule)
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

            /*
             * 当使用 options.FileSets.AddEmbedded<HealDomainSharedModule>() 不带根命名空间参数时，ABP 框架会使用完整的资源名称作为虚拟路径。这意味着我们需要相应地调整 AddVirtualJson 的路径。
             * 这样配置的原因是：
             * 1. AddEmbedded 带命名空间参数时，会将该命名空间作为虚拟文件系统的根路径
             * 2. 这样 Heal.Domain.Shared.Localization.Heal.zh-Hans.json 就会被映射为 /Localization/Heal/zh-Hans.json
             * 3. 这正好与 AddVirtualJson("/Localization/Heal") 的配置相匹配如果不带命名空间参数，则需要使用完整的资源路径，这会导致路径不匹配。所以建议保持带命名空间参数的配置方式。
             */
            options.FileSets.AddEmbedded<HealDomainSharedModule>(typeof(HealDomainSharedModule).Namespace);
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<HealResource>("zh-Hans")
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