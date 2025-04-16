using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Tenants;

/// <summary>
/// 租户配置
/// </summary>
public static class HealAbpTenantManagementDbContextModelCreatingExtensions
{
    public static void ConfigureHealTenantManagement(
        this ModelBuilder builder)
    {

        builder.ConfigureTenantManagement();

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<Tenant>(b =>
        {
            b.ToTable(x => { x.HasComment("租户"); });
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.NormalizedName).HasComment("标准化的名称（通常是去除空格、转换为小写等处理后的名称）");
            b.Property(x => x.EntityVersion).HasComment("实体版本号，用于并发控制或数据版本管理");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<TenantConnectionString>(b =>
        {
            b.ToTable(x => { x.HasComment("租户配置"); });
            b.Property(x => x.Name).HasComment("名称");
            b.Property(x => x.Value).HasComment("值");
            b.ConfigureByConventionBase<Guid>();
        });
    }
}