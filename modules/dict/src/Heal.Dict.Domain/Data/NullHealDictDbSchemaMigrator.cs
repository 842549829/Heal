using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Domain.Data;

/* This is used if database provider does't define
 * IHealDbSchemaMigrator implementation.
 */
public class NullHealDictDbSchemaMigrator : IHealDictDbSchemaMigrator, ITransientDependency
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