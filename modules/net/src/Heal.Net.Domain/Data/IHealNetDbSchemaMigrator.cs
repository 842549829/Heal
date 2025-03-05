using System.Threading.Tasks;

namespace Heal.Data;

public interface IHealNetDbSchemaMigrator
{
    Task MigrateAsync();
}
