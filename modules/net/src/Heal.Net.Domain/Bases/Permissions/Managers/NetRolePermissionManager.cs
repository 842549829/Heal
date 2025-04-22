using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Heal.Net.Domain.Bases.Permissions.Repositories;
using Microsoft.Extensions.Localization;
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
            permissions.AddRange(menuList.Select(menu =>
                CreatePermissionTree(menu.Name, menu.DisplayName, menu)));
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
            Title,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
            ) = ExtractPermissionProperties(permissionName, extra);

        return new PermissionTree(
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
            Title,
            Icon,
            NoCache,
            Breadcrumb,
            Affix,
            ActiveMenu,
            NoTagsView,
            CanTo
        );
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
        string? Title,
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
        var title = extra.GetProperty<string?>(PermissionDefinitionConsts.Title);
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
            Title: title,
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