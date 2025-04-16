using Heal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.PermissionManagement;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// Configures the entity type for the <see cref="Sequences"/> class.
/// </summary>
public static class SequencesHealDbContextModelBuilderExtensions
{
    /// <summary>
    /// Configures the <see cref="Sequences"/> entity.
    /// </summary>
    /// <param name="builder">builder</param>
    public static void ConfigureSequences(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        builder.Entity<Sequences>(b =>
        {
            b.ToTable("Sequences", AbpPermissionManagementDbProperties.DbSchema);

            b.ConfigureByConvention();

            // 设置主键
            b.HasKey(x => x.Id); // 将 Id 设置为主键

            b.Property(x => x.Id)
                .HasColumnName("seq_name")
                .HasMaxLength(50)
                .HasComment("序列名称")
                .IsRequired();

            b.Property(x => x.Value)
                .HasColumnName("seq_value")
                .HasMaxLength(50)
                .HasComment("序列值")
                .IsRequired();

            b.ApplyObjectExtensionMappings();
        });
    }
}