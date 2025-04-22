using Heal.Net.Domain.Bases.Permissions.Modules;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 角色权限领域接口
/// </summary>
public interface INetRolePermissionManager : IHealNetDomainManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="name">角色名称</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    Task SetPermissionAsync(
        string name,
        List<UpdatePermission> updatePermissions);

    /// <summary>
    /// 异步获取权限授予列表
    /// </summary>
    /// <param name="providerName">权限提供者名称</param>
    /// <param name="providerKey">权限提供者密钥</param>
    /// <param name="cancellationToken">用于取消任务的令牌</param>
    /// <returns>返回权限授予列表</returns>
    Task<List<PermissionGrant>> GetPermissionGrantListAsync(
            string providerName,
            string providerKey,
            CancellationToken cancellationToken = default
        );

    /// <summary>
    /// 异步获取指定用户的权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>返回权限树列表</returns>
    Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid userId);
}