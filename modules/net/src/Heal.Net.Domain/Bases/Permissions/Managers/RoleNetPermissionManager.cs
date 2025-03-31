using Heal.Net.Domain.Bases.Permissions.Modules;
using Microsoft.Extensions.Options;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Caching;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SimpleStateChecking;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 角色权限管理器
/// </summary>
/// <param name="permissionDefinitionManager">权限定义管理接口</param>
/// <param name="simpleStateCheckerManager">简单状态检查器管理接口</param>
/// <param name="permissionGrantRepository">权限仓储接口</param>
/// <param name="serviceProvider">服务提供者接口</param>
/// <param name="guidGenerator">uuid创建者接口</param>
/// <param name="options">权限管理配置信息接口</param>
/// <param name="currentTenant">当前租户信息接口</param>
/// <param name="cache">分布式缓存接口</param>
public class RoleNetPermissionManager(
    IPermissionDefinitionManager permissionDefinitionManager,
    ISimpleStateCheckerManager<PermissionDefinition> simpleStateCheckerManager,
    IPermissionGrantRepository permissionGrantRepository,
    IServiceProvider serviceProvider,
    IGuidGenerator guidGenerator,
    IOptions<PermissionManagementOptions> options,
    ICurrentTenant currentTenant,
    IDistributedCache<PermissionGrantCacheItem> cache)
    : PermissionManager(permissionDefinitionManager,
        simpleStateCheckerManager,
        permissionGrantRepository,
        serviceProvider,
        guidGenerator,
        options,
        currentTenant,
        cache), INetRolePermissionManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="entity">角色</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    public Task<IdentityRole> SetPermissionAsync(IdentityRole entity, List<UpdatePermission> updatePermissions)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 异步获取权限授予列表
    /// </summary>
    /// <param name="providerName">权限提供者名称</param>
    /// <param name="providerKey">权限提供者密钥</param>
    /// <param name="cancellationToken">用于取消任务的令牌</param>
    /// <returns>返回权限授予列表</returns>
    public Task<List<PermissionGrant>> GetPermissionGrantListAsync(string providerName, string providerKey,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 异步获取所有权限树列表
    /// </summary>
    /// <returns>返回权限树列表</returns>
    public Task<List<PermissionTree>> GetAllPermissionTreeListAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 异步获取指定用户的权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>返回权限树列表</returns>
    public Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 异步获取权限组定义列表
    /// </summary>
    /// <returns>返回权限组定义列表</returns>
    public Task<List<PermissionGroupDefinitionRecord>> GetPermissionGroupDefinitionListAsync()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 异步获取权限定义列表
    /// </summary>
    /// <param name="groupName">权限组名称</param>
    /// <returns>返回权限定义列表</returns>
    public Task<List<PermissionDefinitionRecord>> GetPermissionDefinitionListAsync(string groupName)
    {
        throw new NotImplementedException();
    }
}