using Volo.Abp.DependencyInjection;

namespace Heal.Net.Domain.Data;

/* This is used if database provider does't define
 * IHealDbSchemaMigrator implementation.
 */
public class NullHealNetDbSchemaMigrator : IHealNetDbSchemaMigrator, ITransientDependency
{
    /// <summary>
    /// Migrate database schema.
    /// </summary>
    /// <returns>Task</returns>
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}