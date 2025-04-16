using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging;
using Volo.Abp.AuditLogging.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.AuditLoggings;

/// <summary>
/// 审计的模型创建扩展方法
/// </summary>
public static class HealAbpAuditLoggingDbContextModelBuilderExtensions
{
    /// <summary>
    /// 审计的模型创建扩展方法
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealAuditLogging(
      this ModelBuilder builder)
    {
        builder.ConfigureAuditLogging();

        builder.Entity<AuditLog>(b =>
        {
            b.ToTable(x => { x.HasComment("审计日志"); });
            b.Property(x => x.ApplicationName).HasComment("应用程序名称");
            b.Property(x => x.ClientIpAddress).HasComment("客户端IP");
            b.Property(x => x.ClientName).HasComment("客户端名称");
            b.Property(x => x.ClientId).HasComment("客户端Id");
            b.Property(x => x.CorrelationId).HasComment("相关联Id");
            b.Property(x => x.BrowserInfo).HasComment("浏览器信息");
            b.Property(x => x.HttpMethod).HasComment("请求方式");
            b.Property(x => x.Url).HasComment("请求Url");
            b.Property(x => x.HttpStatusCode).HasComment("请求响应状态码");
            b.Property(x => x.Comments).HasComment("评论");
            b.Property(x => x.ExecutionDuration).HasComment("执行耗时");
            b.Property(x => x.ImpersonatorTenantId).HasComment("模拟租户Id");
            b.Property(x => x.ImpersonatorUserId).HasComment("模拟用户Id");
            b.Property(x => x.ImpersonatorTenantName).HasComment("模拟租户名称");
            b.Property(x => x.ImpersonatorUserName).HasComment("模拟用户名");
            b.Property(x => x.UserId).HasComment("用户Id");
            b.Property(x => x.UserName).HasComment("用户名");
            b.Property(x => x.TenantId).HasComment("租户Id");
            b.Property(x => x.TenantName).HasComment("租户名称");
            b.Property(x => x.ExecutionTime).HasComment("执行时间");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<AuditLogAction>(b =>
        {
            b.ToTable(x => { x.HasComment("审计日志-Action"); });
            b.Property(x => x.AuditLogId).HasComment(nameof(AuditLogAction.AuditLogId));
            b.Property(x => x.ServiceName).HasComment("服务名称");
            b.Property(x => x.MethodName).HasComment("方法名称");
            b.Property(x => x.Parameters).HasComment("参数");
            b.Property(x => x.ExecutionTime).HasComment("执行时间");
            b.Property(x => x.ExecutionDuration).HasComment("执行耗时");
            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<EntityChange>(b =>
        {
            b.ToTable(x => { x.HasComment("审计日志-Entity"); });
            b.Property(x => x.EntityTypeFullName).HasComment("审计实体全称");
            b.Property(x => x.EntityId).HasComment("审计实体Id");
            b.Property(x => x.AuditLogId).HasComment(nameof(EntityChange.AuditLogId));
            b.Property(x => x.ChangeTime).HasComment("变更时间");
            b.Property(x => x.ChangeType).HasComment("变更类型");
            b.Property(x => x.EntityTenantId).HasComment("审计实体租户Id");

            b.ConfigureByConventionBase<Guid>();
        });

        builder.Entity<EntityPropertyChange>(b =>
        {
            b.ToTable(x => { x.HasComment("审计日志-Entity-Property"); });

            b.Property(x => x.NewValue).HasComment("新值");
            b.Property(x => x.PropertyName).HasComment("属性名称");
            b.Property(x => x.PropertyTypeFullName).HasComment("属性全称");
            b.Property(x => x.OriginalValue).HasComment("旧值");

            b.ConfigureByConventionBase<Guid>();
        });
    }
}