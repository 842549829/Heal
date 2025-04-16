using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Features;

/// <summary>
/// 功能配置
/// </summary>
public static class HealFeatureManagementDbContextModelCreatingExtensions
{
    /// <summary>
    /// 配置功能配置
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealFeatureManagement(
      this ModelBuilder builder)
    {

        builder.ConfigureFeatureManagement();

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<FeatureValue>(b =>
        {
            b.ToTable(x => { x.HasComment("功能配置表"); });
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.Value).HasComment("值");
            b.Property(x => x.ProviderName).HasComment("提供者名称");
            b.Property(x => x.ProviderKey).HasComment("提供者Key");
            b.ConfigureByConventionBase<Guid>();

        });
        builder.Entity<FeatureGroupDefinitionRecord>(b =>
        {
            b.ToTable(x => { x.HasComment("功能分组定义记录");});
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.DisplayName).HasComment("显示名称");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<FeatureDefinitionRecord>(b =>
        {
            b.ToTable(x => { x.HasComment("功能定义"); });

            b.Property(x => x.GroupName).HasComment("所属分组");
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.ParentName).HasComment("父级名称");
            b.Property(x => x.DisplayName).HasComment("显示名称");
            b.Property(x => x.Description).HasComment("描述");
            b.Property(x => x.DefaultValue).HasComment("默认值");
            b.Property(x => x.AllowedProviders).HasComment("允许供应商");
            b.Property(x => x.ValueType).HasComment("值类型");
            b.Property(x => x.IsAvailableToHost).HasComment("主机是否可用");
            b.Property(x => x.IsVisibleToClients).HasComment("对客户端可见");
            b.ConfigureByConventionBase<Guid>();
        });

    }
}