using Heal.Net.Domain.Bases.Permissions.Modules;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 角色权限领域接口
/// </summary>
public interface INetRolePermissionManager : IPermissionManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="entity">角色</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    Task<IdentityRole> SetPermissionAsync(
        IdentityRole entity,
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
    /// 异步获取所有权限树列表
    /// </summary>
    /// <returns>返回权限树列表</returns>
    Task<List<PermissionTree>> GetAllPermissionTreeListAsync();

    /// <summary>
    /// 异步获取指定用户的权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>返回权限树列表</returns>
    Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid userId);

    /// <summary>
    /// 异步获取权限组定义列表
    /// </summary>
    /// <returns>返回权限组定义列表</returns>
    Task<List<PermissionGroupDefinitionRecord>> GetPermissionGroupDefinitionListAsync();

    /// <summary>
    /// 异步获取权限定义列表
    /// </summary>
    /// <param name="groupName">权限组名称</param>
    /// <returns>返回权限定义列表</returns>
    Task<List<PermissionDefinitionRecord>> GetPermissionDefinitionListAsync(string groupName);
}