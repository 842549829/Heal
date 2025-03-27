using Microsoft.Extensions.Diagnostics.HealthChecks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Heal.Net.AuthServer.HealthChecks;

/// <summary>
/// 服务健康检查
/// </summary>
public class HealDatabaseCheck(IIdentityRoleRepository identityRoleRepository) : IHealthCheck, ITransientDependency
{
    /// <summary>
    /// 获取数据库健康检查
    /// </summary>
    protected readonly IIdentityRoleRepository IdentityRoleRepository = identityRoleRepository;

    /// <summary>
    /// 获取数据库健康检查
    /// </summary>
    /// <param name="context">context</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>HealthCheckResult</returns>
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            // 获取数据库记录如果没有异常则返回健康状态
            await IdentityRoleRepository.GetListAsync(sorting: nameof(IdentityRole.Id), maxResultCount: 1, cancellationToken: cancellationToken);

            return HealthCheckResult.Healthy($"Could connect to database and get record.");
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy($"Error when trying to get database record. ", e);
        }
    }
}