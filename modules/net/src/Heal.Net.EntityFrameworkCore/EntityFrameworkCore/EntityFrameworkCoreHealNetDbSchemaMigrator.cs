using Heal.Net.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// EntityFrameworkCore implementation of <see cref="IHealNetDbSchemaMigrator"/>.
/// </summary>
public class EntityFrameworkCoreHealNetDbSchemaMigrator
    : IHealNetDbSchemaMigrator, ITransientDependency
{
    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealNetDbSchemaMigrator"/>.
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealNetDbSchemaMigrator"/>.
    /// </summary>
    /// <param name="serviceProvider">serviceProvider</param>
    public EntityFrameworkCoreHealNetDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealNetDbSchemaMigrator"/>.
    /// </summary>
    /// <returns>Task</returns>
    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HealDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HealNetDbContext>()
            .Database
            .MigrateAsync();
    }
}
