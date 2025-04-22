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
    /// 获取模块(当前登录用户有权限的)
    /// </summary>
    /// <param name="userId">当前登录用户ID</param>
    /// <returns>模块</returns>
    public async Task<List<Module>> GetModuleListAsync(Guid userId)
    {
        // 获取当前用户的角色
        var permissionGrants = await GetPermissionGrants(userId);
        var permissionDefinitionRecords = await permissionGroupDefinitionRecordRepository.GetListAsync(d => permissionGrants.Contains(d.Name));
        return CreateModule(permissionDefinitionRecords);
    }

    /// <summary>
    /// 获取当前模块下对应用户的权限
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <param name="userId">用户Id</param>
    /// <returns>权限</returns>
    public async Task<List<Permission>> GetPermissionsAsync(string moduleName, Guid userId)
    {
        // 获取当前用户的角色
        var permissionGrants = await GetPermissionGrants(userId);
        var permissionDefinitionRecords = await permissionDefinitionRecordRepository.GetListAsync(d => d.GroupName == moduleName && permissionGrants.Contains(d.Name));
        return CreatePermission(permissionDefinitionRecords);
    }

    /// <summary>
    /// 根据用户Id获取权限
    /// </summary>
    /// <param name="userId">用户Id</param>
    /// <returns>权限</returns>
    private async Task<IEnumerable<string>> GetPermissionGrants(Guid userId)
    {
        var roles = await userRepository.GetRolesAsync(userId);
        var providerKey = roles.Select(a => a.Name).ToArray();
        var rolePermission = await permissionRepository.GetPermissionListAsync(RolePermissionValueProvider.ProviderName, providerKey);
        var user = await GetPermissionGrantListAsync(UserPermissionValueProvider.ProviderName, userId.ToString());
        var permissionGrants = rolePermission.Union(user).Select(a => a.Name).Distinct();
        return permissionGrants;
    }

    /// <summary>
    /// 创建权列表
    /// </summary>
    /// <param name="permissionDefinitionRecords">权限定义</param>
    /// <returns>权限树</returns>
    private List<Permission> CreatePermission(List<PermissionDefinitionRecord> permissionDefinitionRecords)
    {
        return permissionDefinitionRecords.Select(menu => CreatePermission(menu.Name, menu.DisplayName, menu)).ToList();
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
    /// 创建权限
    /// </summary>
    /// <param name="permissionName">权限名称</param>
    /// <param name="displayName">显示信息</param>
    /// <param name="extra">权限扩展信息</param>
    /// <returns>结果</returns>
    private Permission CreatePermission(string permissionName, string displayName, IHasExtraProperties extra)
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
        var permission = new Permission(permissionName,
            Deserialize(displayName),
            path,
            component,
            parentName,
            permissionType,
            name,
            redirect,
            alias,
            hidden,
            alwaysShow,
            title,
            icon,
            noCache,
            breadcrumb,
            affix,
            activeMenu,
            noTagsView,
            canTo);
        return permission;
    }

    /// <summary>
    /// 创建模块列表
    /// </summary>
    /// <param name="record">模块</param>
    /// <returns>模块</returns>
    private List<Module> CreateModule(List<PermissionGroupDefinitionRecord> record)
    {
        return record.Select(menu => CreateModule(menu.Name, menu.DisplayName, menu)).ToList();
    }

    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="displayName">显示名称</param>
    /// <param name="extra">扩展参数</param>
    /// <returns>模块</returns>
    private Module CreateModule(string name, string displayName, IHasExtraProperties extra)
    {
        var parentName = extra.GetProperty<string?>(PermissionGroupDefinitionConsts.ParentName);
        var moduleType = (ModuleType?)extra.GetProperty<int?>(PermissionGroupDefinitionConsts.Type) ?? ModuleType.Module;
        var path = extra.GetProperty<string?>(PermissionGroupDefinitionConsts.Path) ?? parentName ?? name;
        var icon = extra.GetProperty<string?>(PermissionGroupDefinitionConsts.Icon);
        var module = new Module(name,
            parentName,
            Deserialize(displayName),
            moduleType,
            path,
            icon
            );
        return module;
    }
}