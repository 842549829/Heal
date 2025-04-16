using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.BackgroundJobs;

/// <summary>
/// 后台任务
/// </summary>
public static class HealBackgroundJobsDbContextModelCreatingExtensions
{
    /// <summary>
    /// 配置后台任务
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealBackgroundJobs(
        this ModelBuilder builder)
    {
        builder.ConfigureBackgroundJobs();

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<BackgroundJobRecord>(b =>
        {
            b.ToTable(x => { x.HasComment("后台任务"); });
            b.Property(x => x.JobName).HasComment("任务名称");
            b.Property(x => x.JobArgs).HasComment("任务参数");
            b.Property(x => x.TryCount).HasComment("重试次数");
            b.Property(x => x.NextTryTime).HasComment("下次运行时间");
            b.Property(x => x.LastTryTime).HasComment("最后一次运行时间");
            b.Property(x => x.IsAbandoned).HasComment("是否放弃了");
            b.Property(x => x.Priority).HasComment("优先级");
            b.ConfigureByConventionBase<Guid>();
        });
    }
}