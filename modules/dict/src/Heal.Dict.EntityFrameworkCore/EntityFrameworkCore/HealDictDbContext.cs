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
    IHealDictDbContext;