using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.EntityFrameworkCore.EntityFrameworkCore.Dictes;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// 字典数据库上下文
/// </summary>
/// <param name="options"></param>

[ConnectionStringName("Dict")]
[ReplaceDbContext(typeof(IHealDictDbContext))]
public class HealDictDbContext(DbContextOptions<HealDictDbContext> options)
    : AbpDbContext<HealDictDbContext>(options),
        IHealDictDbContext
{
    /// <summary>
    /// 字典类型
    /// </summary>
    public DbSet<DictType> DictTypes { get; set; }

    /// <summary>
    /// 字典项
    /// </summary>
    public DbSet<DictItem> DictItems { get; set; }

    /// <summary>
    /// 配置
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureHealDict();
    }
}