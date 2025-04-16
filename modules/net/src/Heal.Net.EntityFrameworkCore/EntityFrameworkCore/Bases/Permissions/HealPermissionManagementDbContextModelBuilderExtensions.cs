using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Permissions;

/// <summary>
/// 权限管理扩展
/// </summary>
public static class HealPermissionManagementDbContextModelBuilderExtensions
{
    /// <summary>
    /// 配置权限管理
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealPermissionManagement(
       this ModelBuilder builder)
    {
        builder.ConfigurePermissionManagement();

        builder.Entity<PermissionGrant>(b =>
        {
            b.ToTable(x =>
            {
                x.HasComment("权限管理");
            });

            b.Property(x => x.Name).HasComment("权限名称");
            b.Property(x => x.ProviderName).HasComment("权限提供者名称(如:角色R)");
            b.Property(x => x.ProviderKey).HasComment("权限提供者Key(如:角色key admin)");

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();
        });

        if (builder.IsHostDatabase())
        {
            builder.Entity<PermissionGroupDefinitionRecord>(b =>
            {
                b.ToTable(x => { x.HasComment("权限分组"); });


                b.Property(x => x.Name).HasComment("权限组名称");
                b.Property(x => x.DisplayName).HasComment("权限组显示名称");

                b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();
            });

            builder.Entity<PermissionDefinitionRecord>(b =>
            {
                b.ToTable(x =>
                {
                    x.HasComment("权限定义");
                });

                b.Property(x => x.GroupName).HasComment("权限组名称");
                b.Property(x => x.Name).HasComment("权限名称");
                b.Property(x => x.ParentName).HasComment("权限父级名称");
                b.Property(x => x.DisplayName).HasComment("权限显示名称");
                b.Property(x => x.Providers).HasComment("权限供应者");
                b.Property(x => x.StateCheckers).HasComment("权限额外属性");
                b.Property(x => x.IsEnabled).HasComment("是否启用");
                b.Property(x => x.MultiTenancySide).HasComment("供应商多个,隔开");

                b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();
            });
        }
    }
}