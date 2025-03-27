namespace Heal.Net.Domain.Data;

/// <summary>
/// 数据库迁移
/// </summary>
public interface IHealNetDbSchemaMigrator
{
    /// <summary>
    /// 数据库迁移
    /// </summary>
    /// <returns>Task</returns>
    Task MigrateAsync();
}
