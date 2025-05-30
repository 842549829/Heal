using Heal.Dict.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// EntityFrameworkCore implementation of <see cref="IHealDictDbSchemaMigrator"/>.
/// </summary>
public class EntityFrameworkCoreHealDictDbSchemaMigrator
    : IHealDictDbSchemaMigrator, ITransientDependency
{
    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealDictDbSchemaMigrator"/>.
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealDictDbSchemaMigrator"/>.
    /// </summary>
    /// <param name="serviceProvider">serviceProvider</param>
    public EntityFrameworkCoreHealDictDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// EntityFrameworkCore implementation of <see cref="IHealDictDbSchemaMigrator"/>.
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
            .GetRequiredService<PermissionManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}