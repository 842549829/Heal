namespace Heal.Dict.Domain.Data;

/// <summary>
/// 数据库迁移
/// </summary>
public interface IHealDictDbSchemaMigrator
{
    /// <summary>
    /// 数据库迁移
    /// </summary>
    /// <returns>Task</returns>
    Task MigrateAsync();
}
