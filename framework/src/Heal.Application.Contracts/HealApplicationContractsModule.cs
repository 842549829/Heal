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
    /// abp生命周期 (后面不在阐述abp生命周期)
    /// 参考地址 https://www.cnblogs.com/WangJunZzz/p/17728392.html
    /// </summary>
    /// <param name="context">当前上下文</param>
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        HealDtoExtensions.Configure();
    }
}