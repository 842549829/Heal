using Heal.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Repositories;

/// <summary>
/// 权限仓库接口
/// </summary>
public interface IPermissionRepository : IHealRepository
{
    /// <summary>
    /// 获取权限列表
    /// </summary>
    /// <param name="providerName">providerName</param>
    /// <param name="providerKey">providerKey</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>权限</returns>
    Task<List<PermissionGrant>> GetPermissionListAsync(string providerName, string[] providerKey, CancellationToken cancellationToken = default);
}