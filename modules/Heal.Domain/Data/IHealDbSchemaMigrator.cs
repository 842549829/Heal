using System.Threading.Tasks;

namespace Heal.Data;

public interface IHealDbSchemaMigrator
{
    Task MigrateAsync();
}
