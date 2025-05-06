using Heal.Dict.Domain.Dictes.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// 字典数据库上下文
/// </summary>
public interface IHealDictDbContext : IEfCoreDbContext
{
    /// <summary>
    /// 字典类型
    /// </summary>
    DbSet<DictType> DictTypes { get; }

    /// <summary>
    /// 字典项
    /// </summary>
    DbSet<DictItem> DictItems { get; }
}