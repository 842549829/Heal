using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore.Dictes;

/// <summary>
/// DbContext扩展
/// </summary>
public static class HealDictDbContextModelBuilderExtensions
{
    /// <summary>
    /// 配置
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealDict(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<DictType>(b =>
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(DictType), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("字典类型");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.ParentId)
                .IsRequired(false)
                .HasColumnName(nameof(DictType.ParentId))
                .HasComment("父级Id");

            b.HasMany(x => x.Items)
            .WithOne()
            .HasForeignKey(x => x.DictTypeId);
        });

        builder.Entity<DictItem>(b =>
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(DictItem), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("字典项");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.DictTypeId)
                .IsRequired()
                .HasColumnName(nameof(DictItem.DictTypeId))
                .HasComment("所属类型Id");

            b.Property(x => x.ParentId)
                .IsRequired(false)
                .HasColumnName(nameof(DictItem.ParentId))
                .HasComment("父级Id");

            b.Property(x => x.Alias)
                .IsRequired(false)
                .HasColumnName(nameof(DictItem.Alias))
                .HasMaxLength(DictItemConstants.MaxAliasLength)
                .HasComment("别名");

            b.Property(x => x.Style)
                .IsRequired(false)
                .HasColumnName(nameof(DictItem.Style))
                .HasMaxLength(DictItemConstants.MaxStyleLength)
                .HasComment("样式");

            b.Property(x => x.Key)
                .IsRequired()
                .HasColumnName(nameof(DictItem.Key))
                .HasMaxLength(DictItemConstants.MaxKeyLength)
                .HasComment("键");

        });
    }
}