using Heal.Domain;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.Studio;

namespace Heal.EntityFrameworkCore;

/// <summary>
/// HealEntityFrameworkCoreModule
/// </summary>
[DependsOn(
    typeof(HealDomainModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    //typeof(AbpEntityFrameworkCoreMySQLPomeloModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpIdentityEntityFrameworkCoreModule)
)]
public class HealEntityFrameworkCoreModule : AbpModule
{
    /// <summary>
    /// ConfigureServices
    /// </summary>
    /// <param name="context">context</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<HealDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        if (AbpStudioAnalyzeHelper.IsInAnalyzeMode)
        {
            return;
        }

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also HealDbContextFactory for EF Core tooling. */

            options.UseMySQL(builder =>
            {
                builder.TranslateParameterizedCollectionsToConstants();
            });

        });
    }
}