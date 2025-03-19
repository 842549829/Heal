using Heal.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace Heal.Application.Contracts;

/// <summary>
/// HealApplicationContractsModule
/// </summary>
[DependsOn(
    typeof(HealDomainSharedModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule)
)]
public class HealApplicationContractsModule : AbpModule
{
    /// <summary>
    /// PreConfigureServices
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        HealDtoExtensions.Configure();
    }
}