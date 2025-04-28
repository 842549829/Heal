using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Heal.Net.Domain.Bases.Permissions.Repositories;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;

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
public class NetRolePermissionManager(
    IPermissionGrantRepository permissionGrantRepository,
    RolePermissionManagementProvider permissionManagementProvider,
    IRepository<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecordRepository,
    IRepository<PermissionDefinitionRecord> permissionDefinitionRecordRepository,
    IPermissionRepository permissionRepository,
    IIdentityUserRepository userRepository)
    : HealNetDomainManager, INetRolePermissionManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="name">角色</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    public async Task SetPermissionAsync(string name, List<UpdatePermission> updatePermissions)
    {
        if (updatePermissions.IsNullOrEmpty())
        {
            return;
        }

        // 功能权限
        foreach (var item in updatePermissions)
        {
            await permissionManagementProvider.SetAsync(item.Name, name, item.IsGranted);
        }
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
    /// 异步获取指定用户的权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="groupName">组名称</param>
    /// <returns>返回权限树列表</returns>
    public async Task<List<PermissionTree>> GetModuleAndPermissionTreeListAsync(Guid? userId = null, string? groupName = null)
    {
        // 获取模块列表
        async Task<List<PermissionGroupDefinitionRecord>> GetModuleDataAsync(string[] modules)
        {
            var permissionGroupDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync(d => modules.Contains(d.Name));
            return permissionGroupDefinitionRecords;
        }

        string[] GetGroupNames(List<PermissionDefinitionRecord> permissionDefinitionRecords)
        {
            var groupNames = groupName.IsNullOrEmpty() ? permissionDefinitionRecords.Select(a => a.GroupName).Distinct().ToArray() : [groupName];
            return groupNames;
        }

        // 构建权限树
        List<PermissionTree> BuildPermissionTree(List<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecords, List<PermissionDefinitionRecord> permissionDefinitionRecords)
        {
            var permissions = CreatePermissionTree(permissionGroupDefinitionRecords, permissionDefinitionRecords);
            return ConvertToTree(permissions);
        }

        if (!userId.HasValue)
        {
            // 未提供用户 ID 的情况
            var permissionDefinitionRecords = await GetPermissionDataAsync(module: groupName);
            var groupNames = GetGroupNames(permissionDefinitionRecords);
            var permissionGroupDefinitionRecords = await GetModuleDataAsync(groupNames);
            return BuildPermissionTree(permissionGroupDefinitionRecords, permissionDefinitionRecords);
        }
        else
        {
            // 提供了用户 ID 的情况
            var roles = await userRepository.GetRolesAsync(userId.Value);
            var providerKey = roles.Select(a => a.Name).ToArray();
            var rolePermission = await permissionRepository.GetPermissionListAsync(RolePermissionValueProvider.ProviderName, providerKey);
            var user = await GetPermissionGrantListAsync(UserPermissionValueProvider.ProviderName, userId.Value.ToString());
            var permissionGrants = rolePermission.Union(user).Select(a => a.Name).Distinct().ToList();
            var permissionDefinitionRecords = await GetPermissionDataAsync(permissionGrants, groupName);
            var groupNames = GetGroupNames(permissionDefinitionRecords);
            var permissionGroupDefinitionRecords = await GetModuleDataAsync(groupNames);
            return BuildPermissionTree(permissionGroupDefinitionRecords, permissionDefinitionRecords);
        }
    }

    /// <summary>
    /// 获取权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="groupName">组名称</param>
    /// <returns>返回权限树列表</returns>
    public async Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid? userId = null, string? groupName = null)
    {
        if (!userId.HasValue)
        {
            // 未提供用户 ID 的情况
            var permissionDefinitionRecords = await GetPermissionDataAsync(module: groupName);
            return BuildPermissionTree(permissionDefinitionRecords);
        }
        else
        {
            // 提供了用户 ID 的情况
            var roles = await userRepository.GetRolesAsync(userId.Value);
            var providerKey = roles.Select(a => a.Name).ToArray();
            var rolePermission = await permissionRepository.GetPermissionListAsync(RolePermissionValueProvider.ProviderName, providerKey);
            var user = await GetPermissionGrantListAsync(UserPermissionValueProvider.ProviderName, userId.Value.ToString());
            var permissionGrants = rolePermission.Union(user).Select(a => a.Name).Distinct().ToList();
            var permissionDefinitionRecords = await GetPermissionDataAsync(permissionGrants, groupName);
            return BuildPermissionTree(permissionDefinitionRecords);
        }

        // 构建权限树
        List<PermissionTree> BuildPermissionTree(List<PermissionDefinitionRecord> permissionDefinitionRecords)
        {
            var permissions = new List<PermissionTree>();
            permissions.AddRange(permissionDefinitionRecords.Select(menu => CreatePermissionTree(menu.Name, menu.DisplayName, menu)));
            return ConvertToTree(permissions);
        }
    }

    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <param name="userId">用户Id</param>
    /// <returns>权限</returns>
    public async Task<List<Permission>> GetModuleListAsync(Guid? userId = null)
    {
        var permissionGroupDefinitionRecordList = await GetModuleDataAsync();
        return CreatePermission(permissionGroupDefinitionRecordList);

        // 获取模块列表
        async Task<List<PermissionGroupDefinitionRecord>> GetModuleDataAsync()
        {
            // 提供了用户 ID 的情况
            if (!userId.HasValue)
            {
                return await permissionGroupDefinitionRecordRepository.GetListAsync();
            }

            var roles = await userRepository.GetRolesAsync(userId.Value);
            var providerKey = roles.Select(a => a.Name).ToArray();
            var rolePermission = await permissionRepository.GetPermissionListAsync(RolePermissionValueProvider.ProviderName, providerKey);
            var user = await GetPermissionGrantListAsync(UserPermissionValueProvider.ProviderName, userId.Value.ToString());
            var permissionGrants = rolePermission.Union(user).Select(a => a.Name).Distinct().ToList();
            var permissionDefinitionRecords = await GetPermissionDataAsync(permissionGrants);
            var modules = permissionDefinitionRecords.Select(a => a.GroupName).Distinct().ToArray();
            var permissionGroupDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync(d => modules.Contains(d.Name) || permissionGrants.Contains(d.Name));
            return permissionGroupDefinitionRecords;

        }
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
            var modulePermission = CreatePermissionTree(permissionGroupDefinitionRecord.Name, permissionGroupDefinitionRecord.DisplayName, permissionGroupDefinitionRecord);
            var menuList = permissionDefinitionRecords.Where(d => d.GroupName == modulePermission.Name);
            permissions.AddRange(menuList.Select(menu => CreatePermissionTree(menu.Name, menu.DisplayName, menu)));
            permissions.Add(modulePermission);
        }

        return permissions;
    }

    /// <summary>
    /// 创建权限
    /// </summary>
    /// <param name="permissionGroupDefinitionRecords">权限分组</param>
    /// <returns>权限</returns>
    private List<Permission> CreatePermission(
        List<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecords)
    {
        return permissionGroupDefinitionRecords.Select(permissionGroupDefinitionRecord => CreatePermission(permissionGroupDefinitionRecord.Name, permissionGroupDefinitionRecord.DisplayName, permissionGroupDefinitionRecord)).ToList();
    }

    /// <summary>
    /// 获权限模块列表
    /// </summary>
    /// <param name="name">权限名称</param>
    /// <param name="module">模块名称</param>
    /// <returns>权限定义</returns>
    private async Task<List<PermissionDefinitionRecord>> GetPermissionDataAsync(List<string>? name = null, string? module = null)
    {
        // 构建查询条件
        Expression<Func<PermissionDefinitionRecord, bool>> predicate = d => true; // 默认条件
        if (!string.IsNullOrEmpty(module))
        {
            predicate = predicate.And(d => d.GroupName == module);
        }

        if (name != null && name.Any())
        {
            predicate = predicate.And(d => name.Contains(d.Name));
        }
        var permissionDefinitionRecords = await permissionDefinitionRecordRepository.GetListAsync(predicate);
        return permissionDefinitionRecords;
    }

    /// <summary>
    /// 将权限树列表转换为树形结构
    /// </summary>
    /// <param name="permissions">权限树</param>
    /// <param name="parentName">上级权限名称</param>
    /// <returns>权限树</returns>
    private static List<PermissionTree> ConvertToTree(List<PermissionTree> permissions, string? parentName = null)
    {
        var permissionsList = permissions.Where(d => d.ParentName == parentName);
        var list = new List<PermissionTree>();
        foreach (var item in permissionsList)
        {
            var permissionTree = item.Clone();
            var children = ConvertToTree(permissions, item.Name);
            foreach (var child in children)
            {
                permissionTree.AddChildPermission(child);
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

    /// <summary>
    /// 创建权限数据对象
    /// </summary>
    /// <param name="permissionName">权限名称</param>
    /// <param name="displayName">显示信息</param>
    /// <param name="extra">权限扩展信息</param>
    /// <returns>结果</returns>
    private Permission CreatePermission(string permissionName, string displayName, IHasExtraProperties extra)
    {
        var (
            Path,
            Component,
            ParentName,
            PermissionType,
            Name,
            Redirect,
            Alias,
            Hidden,
            AlwaysShow,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
            ) = ExtractPermissionProperties(permissionName, extra);

        var permission = new Permission(
            permissionName,
            Deserialize(displayName),
            Path,
            Component,
            ParentName,
            PermissionType,
            Name,
            Redirect,
            Alias,
            Hidden,
            AlwaysShow,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
        );
        var path = extra.GetProperty<int?>(PermissionDefinitionConsts.Tag) ?? 0;
        permission.SetTag(path);
        return permission;
    }

    /// <summary>
    /// 创建权限数据对象
    /// </summary>
    /// <param name="permissionName">权限名称</param>
    /// <param name="displayName">显示信息</param>
    /// <param name="extra">权限扩展信息</param>
    /// <returns>结果</returns>
    private PermissionTree CreatePermissionTree(string permissionName, string displayName, IHasExtraProperties extra)
    {
        var (
            Path,
            Component,
            ParentName,
            PermissionType,
            Name,
            Redirect,
            Alias,
            Hidden,
            AlwaysShow,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
            ) = ExtractPermissionProperties(permissionName, extra);

        var permissionTree = new PermissionTree(
            permissionName,
            Deserialize(displayName),
            Path,
            Component,
            ParentName,
            PermissionType,
            Name,
            Redirect,
            Alias,
            Hidden,
            AlwaysShow,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
        );
        var path = extra.GetProperty<int?>(PermissionDefinitionConsts.Tag) ?? 0;
        permissionTree.SetTag(path);
        return permissionTree;
    }

    /// <summary>
    /// 从扩展属性中提取权限相关参数。
    /// </summary>
    /// <param name="permissionName">权限名称</param>
    /// <param name="extra">扩展属性</param>
    /// <returns>权限相关参数的元组</returns>
    private static (
        string Path,
        string Component,
        string? ParentName,
        PermissionType PermissionType,
        string? Name,
        string? Redirect,
        string? Alias,
        bool? Hidden,
        bool? AlwaysShow,
        string? Icon,
        bool? NoCache,
        bool? Breadcrumb,
        bool? Affix,
        string? ActiveMenu,
        bool? NoTagsView,
        bool? CanTo
    ) ExtractPermissionProperties(string permissionName, IHasExtraProperties extra)
    {
        var path = extra.GetProperty<string?>(PermissionDefinitionConsts.Path) ?? permissionName;
        var component = extra.GetProperty<string?>(PermissionDefinitionConsts.Component) ?? path;
        var parentName = extra.GetProperty<string?>(PermissionDefinitionConsts.ParentName);
        var permissionType = (PermissionType?)extra.GetProperty<int?>(PermissionDefinitionConsts.Type) ?? PermissionType.Menu;
        var name = extra.GetProperty<string?>(PermissionDefinitionConsts.Name);
        var redirect = extra.GetProperty<string?>(PermissionDefinitionConsts.Redirect);
        var alias = extra.GetProperty<string?>(PermissionDefinitionConsts.Alias);
        var hidden = extra.GetProperty<bool?>(PermissionDefinitionConsts.Hidden);
        var alwaysShow = extra.GetProperty<bool?>(PermissionDefinitionConsts.AlwaysShow);
        var icon = extra.GetProperty<string?>(PermissionDefinitionConsts.Icon);
        var noCache = extra.GetProperty<bool?>(PermissionDefinitionConsts.NoCache);
        var breadcrumb = extra.GetProperty<bool?>(PermissionDefinitionConsts.Breadcrumb);
        var affix = extra.GetProperty<bool?>(PermissionDefinitionConsts.Affix);
        var activeMenu = extra.GetProperty<string?>(PermissionDefinitionConsts.ActiveMenu);
        var noTagsView = extra.GetProperty<bool?>(PermissionDefinitionConsts.NoTagsView);
        var canTo = extra.GetProperty<bool?>(PermissionDefinitionConsts.CanTo);

        return (
            Path: path,
            Component: component,
            ParentName: parentName,
            PermissionType: permissionType,
            Name: name,
            Redirect: redirect,
            Alias: alias,
            Hidden: hidden,
            AlwaysShow: alwaysShow,
            Icon: icon,
            NoCache: noCache,
            Breadcrumb: breadcrumb,
            Affix: affix,
            ActiveMenu: activeMenu,
            NoTagsView: noTagsView,
            CanTo: canTo
        );
    }
}