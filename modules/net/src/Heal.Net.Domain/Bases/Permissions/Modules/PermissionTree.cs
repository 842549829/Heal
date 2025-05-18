using Heal.Domain.Shared.Enums;

namespace Heal.Net.Domain.Bases.Permissions.Modules;

/// <summary>
/// 权限树
/// </summary>
public class PermissionTree : PermissionBase
{
    /// <summary>
    /// 初始化 <see cref="PermissionTree"/> 类的新实例。
    /// </summary>
    /// <param name="permissionName">权限名称。</param>
    /// <param name="displayName">权限显示名称（可选）。</param>
    /// <param name="path">权限前端路由（可选）。用于前端路由匹配。</param>
    /// <param name="component">与该路由对应的组件（必填）。指定前端加载的组件路径。</param>
    /// <param name="parentName">父级权限名称（可选）。</param>
    /// <param name="type">权限类型（可选）。表示权限的分类，例如菜单、按钮等。</param>
    /// <param name="name">路由名称（可选）。用于编程式导航，例如 `router.push({ name: 'Home' })`。</param>
    /// <param name="redirect">重定向路径（可选）。可以是字符串或动态路径。</param>
    /// <param name="alias">别名（可选）。访问别名路径时会匹配原始路径的路由。</param>
    /// <param name="hidden">是否隐藏该路由（可选）。如果为 true，则该路由不会显示在菜单中。</param>
    /// <param name="alwaysShow">是否始终显示根菜单（可选）。如果为 true，即使只有一个子路由，也会显示父级菜单。</param>
    /// <param name="icon">权限前端图标（可选）。指定菜单项的图标。</param>
    /// <param name="noCache">是否禁用页面缓存（可选）。如果为 true，则该页面不会被缓存。</param>
    /// <param name="breadcrumb">是否显示面包屑导航（可选）。如果为 false，则该路由不会出现在面包屑中。</param>
    /// <param name="affix">是否固定在标签页中（可选）。如果为 true，则该路由会始终显示在标签页中。</param>
    /// <param name="activeMenu">当前路由激活时需要高亮的菜单项路径（可选）。</param>
    /// <param name="noTagsView">是否禁用标签页视图（可选）。如果为 true，则该路由不会显示在标签页中。</param>
    /// <param name="canTo">是否允许跳转到该路由（可选）。如果为 false，则无法通过编程式导航跳转到该路由。</param>
    public PermissionTree(string permissionName,
        string displayName,
        string path,
        string component,
        string? parentName = null,
        PermissionType? type = PermissionType.Menu,
        string? name = null,
        string? redirect = null,
        string? alias = null,
        bool? hidden = false,
        bool? alwaysShow = false,
        string? icon = null,
        bool? noCache = null,
        bool? breadcrumb = null,
        bool? affix = null,
        string? activeMenu = null,
        bool? noTagsView = false,
        bool? canTo = false) : base(permissionName, displayName, path, component, parentName, type, name, redirect, alias, hidden, alwaysShow, icon, noCache, breadcrumb, affix, activeMenu, noTagsView, canTo)
    {
    }

    /// <summary>
    /// 子权限
    /// </summary>
    public List<PermissionTree>? ChildPermissions { get; private set; }

    /// <summary>
    /// 添加子权限
    /// </summary>
    /// <param name="childPermission">子权限</param>
    public void AddChildPermission(PermissionTree childPermission)
    {
        ChildPermissions ??= [];
        ChildPermissions.Add(childPermission);
    }
    
    /// <summary>
    /// 添加子权限
    /// </summary>
    /// <param name="childPermissions">子权限</param>
    public void AddChildPermission(List<PermissionTree> childPermissions)
    {
        ChildPermissions ??= [];
        ChildPermissions.AddRange(childPermissions);
    }

    /// <summary>
    /// 克隆
    /// </summary>
    /// <returns>权限树</returns>
    public PermissionTree Clone()
    {
        var permissionTree = this;
        return new PermissionTree(permissionTree.PermissionName,
            permissionTree.Title,
            permissionTree.Path,
            permissionTree.Component,
            permissionTree.ParentName,
            permissionTree.Type,
            permissionTree.Name,
            permissionTree.Redirect,
            permissionTree.Alias,
            permissionTree.Hidden,
            permissionTree.AlwaysShow,
            permissionTree.Icon,
            permissionTree.NoCache,
            permissionTree.Breadcrumb,
            permissionTree.Affix,
            permissionTree.ActiveMenu,
            permissionTree.NoTagsView,
            permissionTree.CanTo);
    }
}