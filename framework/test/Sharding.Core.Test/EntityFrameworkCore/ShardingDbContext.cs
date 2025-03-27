using Microsoft.EntityFrameworkCore;
using Sharding.Core.Test.Entities;
using ShardingCore.Core.VirtualRoutes.TableRoutes.RouteTails.Abstractions;
using ShardingCore.Sharding;
using ShardingCore.Sharding.Abstractions;

namespace Sharding.Core.Test.EntityFrameworkCore
{
    /// <summary>
    /// 分表DbContext
    /// </summary>
    /// <param name="options">配置</param>
    public class ShardingDbContext(DbContextOptions<ShardingDbContext> options)
        : AbstractShardingDbContext(options), IShardingTableDbContext
    {
        /// <summary>
        /// 配置实体
        /// </summary>
        /// <param name="modelBuilder">模型创建对象</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Id).IsRequired().IsUnicode(false).HasMaxLength(50);
                entity.Property(o => o.Payer).IsRequired().IsUnicode(false).HasMaxLength(50);
                entity.Property(o => o.Area).IsRequired().IsUnicode(false).HasMaxLength(50);
                entity.Property(o => o.OrderStatus).HasConversion<int>();
                entity.ToTable(nameof(Order));
            });
        }
        /// <summary>
        /// empty impl if use sharding table
        /// </summary>
        public IRouteTail RouteTail { get; set; } = null!;
    }
}
