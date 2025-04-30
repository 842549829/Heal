using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Heal.Dict.Domain;
using Heal.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.Studio;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// HealDictEntityFrameworkCoreModule
/// </summary>
[DependsOn(
    typeof(HealDictDomainModule),
    typeof(HealEntityFrameworkCoreModule)
)]
public class HealDictEntityFrameworkCoreModule : AbpModule
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

            options.UseMySQL(builder => { builder.TranslateParameterizedCollectionsToConstants(); });
        });
    }
}