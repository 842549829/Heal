using System;
using System.Threading.Tasks;
using Heal.Net.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

public class EntityFrameworkCoreHealNetDbSchemaMigrator
    : IHealNetDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHealNetDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

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
