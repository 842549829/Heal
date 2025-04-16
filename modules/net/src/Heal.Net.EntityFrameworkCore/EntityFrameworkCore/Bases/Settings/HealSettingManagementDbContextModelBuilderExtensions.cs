using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Settings;

/// <summary>
/// 配置扩展
/// </summary>
public static class HealSettingManagementDbContextModelBuilderExtensions
{
    /// <summary>
    /// 配置设置扩展
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealSettingManagement(
        this ModelBuilder builder)
    {
        builder.ConfigureSettingManagement();

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<Setting>(b =>
        {
            b.ToTable(x =>
            {
                x.HasComment("配置表");
            });

            b.Property(x => x.Name).HasComment("配置名称");
            b.Property(x => x.Value).HasComment("配置值");
            b.Property(x => x.ProviderName).HasComment("提供者名称");
            b.Property(x => x.ProviderKey).HasComment("提供者Key");
            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();
        });

        builder.Entity<SettingDefinitionRecord>(b =>
        {
            b.ToTable(x =>
            {
                x.HasComment("配置定义");
            });

            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.DisplayName).HasComment("显示名称");
            b.Property(x => x.Description).HasComment("描述");
            b.Property(x => x.DefaultValue).HasComment("默认值");
            b.Property(x => x.Providers).HasComment("提供者多个,隔开");
            b.Property(x => x.IsInherited).HasComment("此设置是从父作用域继承的吗");
            b.Property(x => x.IsEncrypted).HasComment("此设置是否以加密方式存储在数据源中");

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();
        });
    }
}