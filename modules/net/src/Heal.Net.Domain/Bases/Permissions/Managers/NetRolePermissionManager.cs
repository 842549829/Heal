using Heal.Domain.Shared.Constant;
using Heal.Domain.Shared.Enums;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Heal.Net.Domain.Bases.Permissions.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 角色权限管理器
/// </summary>
/// <param name="permissionGrantRepository">权限仓储接口</param>
/// <param name="permissionManagementProvider">权限管理提供者接口</param>
/// <param name="permissionGroupDefinitionRecordRepository">权限分组定义记录接口</param>
/// <param name="permissionDefinitionRecordRepository">权限定义记录接口</param>
/// <param name="permissionRepository">权限仓储接口</param>
/// <param name="userRepository">用户仓储接口</param>
public class NetRolePermissionManager(IPermissionGrantRepository permissionGrantRepository,
    IPermissionManagementProvider permissionManagementProvider,
    IRepository<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecordRepository,
    IRepository<PermissionDefinitionRecord> permissionDefinitionRecordRepository,
    IPermissionRepository permissionRepository,
    IIdentityUserRepository userRepository)
    : HealNetDomainManager, INetRolePermissionManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="entity">角色</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    public async Task<IdentityRole> SetPermissionAsync(IdentityRole entity, List<UpdatePermission> updatePermissions)
    {
        if (updatePermissions.IsNullOrEmpty())
        {
            return entity;
        }

        // 功能权限
        foreach (var item in updatePermissions)
        {
            await permissionManagementProvider.SetAsync(item.Name, entity.Name, item.IsGranted);
        }

        return entity;
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
        return permissionGrantRepository.GetListAsync(providerName, providerKey, cancellationToken);
    }

    /// <summary>
    /// 异步获取所有权限树列表
    /// </summary>
    /// <returns>返回权限树列表</returns>
    public async Task<List<PermissionTree>> GetAllPermissionTreeListAsync()
    {
        var permissionGroupDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync();
        var permissionDefinitionRecords = await permissionDefinitionRecordRepository.GetListAsync(d => d.IsEnabled);
        var permissions = CreatePermissionTree(permissionGroupDefinitionRecords, permissionDefinitionRecords);
        var result = ConvertToTree(permissions);
        return result;
    }

    /// <summary>
    /// 异步获取指定用户的权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns>返回权限树列表</returns>
    public async Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid userId)
    {
        // 获取当前用户的角色
        var roles = await userRepository.GetRolesAsync(userId);
        var providerKey = roles.Select(a => a.Name).ToArray();
        var rolePermission = await permissionRepository.GetPermissionListAsync(RolePermissionValueProvider.ProviderName, providerKey);
        var user = await GetPermissionGrantListAsync(UserPermissionValueProvider.ProviderName, userId.ToString());
        var permissionGrants = rolePermission.Union(user).Select(a => a.Name).Distinct();
        var permissionDefinitionRecords = await permissionDefinitionRecordRepository.GetListAsync(d => permissionGrants.Contains(d.Name));
        var groupNames = permissionDefinitionRecords.Select(a => a.GroupName).Distinct().ToArray();
        var permissionGroupDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync(d => groupNames.Contains(d.Name));
        var permissions = CreatePermissionTree(permissionGroupDefinitionRecords, permissionDefinitionRecords);
        var result = ConvertToTree(permissions);
        return result;
    }

    /// <summary>
    /// 异步获取权限组定义列表
    /// </summary>
    /// <returns>返回权限组定义列表</returns>
    public async Task<List<PermissionGroupDefinitionRecord>> GetPermissionGroupDefinitionListAsync()
    {
        var permissionGroupDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync();
        foreach (var permissionGroupDefinitionRecord in permissionGroupDefinitionRecords)
        {
            permissionGroupDefinitionRecord.DisplayName = Deserialize(permissionGroupDefinitionRecord.DisplayName);
        }

        return permissionGroupDefinitionRecords;
    }

    /// <summary>
    /// 异步获取权限定义列表
    /// </summary>
    /// <param name="groupName">权限组名称</param>
    /// <returns>返回权限定义列表</returns>
    public async Task<List<PermissionDefinitionRecord>> GetPermissionDefinitionListAsync(string groupName)
    {
        var permissionDefinitionRecords = await permissionDefinitionRecordRepository.GetListAsync(d => d.GroupName == groupName);
        foreach (var permissionDefinitionRecord in permissionDefinitionRecords)
        {
            permissionDefinitionRecord.DisplayName = Deserialize(permissionDefinitionRecord.DisplayName);
        }
        return permissionDefinitionRecords;
    }

    /// <summary>
    /// 创建权限树
    /// </summary>
    /// <param name="permissionGroupDefinitionRecords">权限分组</param>
    /// <param name="permissionDefinitionRecords">权限定义</param>
    /// <returns>权限树</returns>
    private List<PermissionTree> CreatePermissionTree(
       List<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecords,
       List<PermissionDefinitionRecord> permissionDefinitionRecords)
    {
        var permissions = new List<PermissionTree>();
        foreach (var permissionGroupDefinitionRecord in permissionGroupDefinitionRecords)
        {
            var modulePermission = new PermissionTree(permissionGroupDefinitionRecord.Name,
                Deserialize(permissionGroupDefinitionRecord.DisplayName),
                PermissionType.Module,
                path: permissionGroupDefinitionRecord.GetProperty<string>(PermissionDefinitionConsts.Path),
                iocn: permissionGroupDefinitionRecord.GetProperty<string>(PermissionDefinitionConsts.Icon));
            var menuList = permissionDefinitionRecords.Where(d => d.GroupName == modulePermission.Name);
            permissions.AddRange(menuList.Select(menu =>
                new PermissionTree(menu.Name, Deserialize(menu.DisplayName),
                    type: (PermissionType?)menu.GetProperty<int?>(PermissionDefinitionConsts.Type),
                    path: menu.GetProperty<string?>(PermissionDefinitionConsts.Path),
                    iocn: menu.GetProperty<string?>(PermissionDefinitionConsts.Icon),
                    parentName: menu.ParentName ?? menu.GroupName)));
            permissions.Add(modulePermission);
        }

        return permissions;
    }

    /// <summary>
    /// 将权限树列表转换为树形结构
    /// </summary>
    /// <param name="permissions">权限树</param>
    /// <param name="parentName">上级权限名称</param>
    /// <returns>权限树</returns>
    private List<PermissionTree> ConvertToTree(List<PermissionTree> permissions, string? parentName = null)
    {
        var permissionsList = permissions.Where(d => d.ParentName == parentName);
        var list = new List<PermissionTree>();
        foreach (var item in permissionsList)
        {
            var permissionTree = new PermissionTree(item.Name,
                Deserialize(item.DisplayName!),
                item.Type,
                item.Path,
                item.Iocn,
                item.ParentName);
            var children = ConvertToTree(permissions, item.Name);
            foreach (var child in children)
            {
                permissionTree.AddChildPermissions(child);
            }

            list.Add(permissionTree);
        }

        return list;
    }

    /// <summary>
    /// 本地化字符串反序列化
    /// </summary>
    /// <param name="value">显示名key</param>
    /// <returns>显示名</returns>
    private LocalizedString Deserialize(string value)
    {
        return L[value];
    }
}