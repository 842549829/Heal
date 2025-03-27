using Heal.HttpApi.Client;
using Heal.Net.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace Heal.Net.HttpApi.Client;

/// <summary>
/// HealNetHttpApiClientModule
/// api/abp/api-definition  远程调用检查接口是否正确
/// </summary>
[DependsOn(
    typeof(HealHttpApiClientModule),
    typeof(HealNetApplicationContractsModule),
    typeof(AbpFeatureManagementHttpApiClientModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpTenantManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class HealNetHttpApiClientModule : AbpModule
{
    /// <summary>
    /// RemoteServiceName
    /// </summary>
    public const string RemoteServiceName = "HealNet";

    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(HealNetApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<HealNetHttpApiClientModule>();
        });
    }
}
