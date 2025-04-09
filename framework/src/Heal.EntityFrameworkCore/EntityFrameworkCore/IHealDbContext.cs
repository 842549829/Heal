using Heal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// IHealDbContext
/// </summary>
[ConnectionStringName("Heal")]
public interface IHealDbContext : IEfCoreDbContext
{
    /// <summary>
    /// 序列
    /// </summary>
    DbSet<Sequences> Sequences { get; set; }
}