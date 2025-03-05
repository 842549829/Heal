using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Heal.Data;

/* This is used if database provider does't define
 * IHealDbSchemaMigrator implementation.
 */
public class NullHealNetDbSchemaMigrator : IHealNetDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
