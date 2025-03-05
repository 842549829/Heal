using System.Threading.Tasks;

namespace Heal.Net.Domain.Data;

public interface IHealNetDbSchemaMigrator
{
    Task MigrateAsync();
}
