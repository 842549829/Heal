using Heal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// 基础数据库
/// </summary>

public class HealDbContext : AbpDbContext<HealDbContext>, IHealDbContext
{
    /// <summary>
    /// 基础数据库
    /// </summary>
    /// <param name="options">配置</param>
    public HealDbContext(DbContextOptions<HealDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// 序列
    /// </summary>
    public DbSet<Sequences> Sequences { get; set; }

    /// <summary>
    /// Configure the model here or remove if not needed.
    /// </summary>
    /// <param name="builder">builder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureSequences();
    }
}