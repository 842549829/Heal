using Heal.Application;
using Heal.Domain.Shared.Options;
using Heal.Net.Application.Contracts;
using Heal.Net.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Heal.Net.Application;

/// <summary>
/// HealNetApplicationModule
/// </summary>
[DependsOn(
    typeof(HealNetDomainModule),
    typeof(HealApplicationModule),
    typeof(HealNetApplicationContractsModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class HealNetApplicationModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var services = context.Services;

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<HealNetApplicationModule>();
        });

        Configure<IdentityOptions>(options =>
        {
            // 配置密码规则
            //options.Password.RequireUppercase = false;
            //options.Password.RequireLowercase = false;

            // 配置用户登录失败连错误20次则锁定帐号10分钟
            options.Lockout.MaxFailedAccessAttempts = 20;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10.0);
        });

        // 授权信息配置
        Configure<AuthServerOptions>(configuration.GetSection("AuthServer"));

        // 注册网络请求
        services.AddHttpClient();
    }
}