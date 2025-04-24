using Heal.Domain.Shared.Enums;

namespace Heal.Net.Domain.Bases.Permissions.Modules;

/// <summary>
/// 权限基类
/// </summary>
public abstract class PermissionBase : IRouteConfig
{
    /// <summary>
    /// 初始化 <see cref="PermissionBase"/> 类的新实例。
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
    protected PermissionBase(string permissionName,
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
        bool? canTo = false)
    {
        PermissionName = permissionName;
        ParentName = parentName;
        Type = type;
        Path = path;
        Name = name;
        Component = component;
        Redirect = redirect;
        Alias = alias;
        Hidden = hidden;
        AlwaysShow = alwaysShow;
        Title = displayName;
        Icon = icon;
        NoCache = noCache;
        Breadcrumb = breadcrumb;
        Affix = affix;
        ActiveMenu = activeMenu;
        NoTagsView = noTagsView;
        CanTo = canTo;
    }

    /// <summary>
    /// 权限名称
    /// </summary>
    public string PermissionName { get; private set; }

    /// <summary>
    /// 父级权限名称
    /// </summary>
    public string? ParentName { get; private set; }

    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType? Type { get; private set; }

    /// <summary>
    /// 标签[特殊标记;不如1标记是跳转第三方的]
    /// </summary>
    public int Tag { get; private set; }

    /// <summary>
    /// 设置标签
    /// </summary>
    /// <param name="tag">tag</param>
    public void SetTag(int tag)
    {
        Tag = tag;
    }

    /// <summary>
    /// 权限前端路由
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// 可选。路由名称，用于编程式导航（如 router.push({ name: 'Home' })）。
    /// </summary>
    public string? Name { get; private set; }

    /// <summary>
    /// 必填。与该路由对应的组件。
    /// </summary>
    public string Component { get; private set; }

    /// <summary>
    /// 可选。重定向到另一个路径（可以是字符串或函数）。
    /// </summary>
    public string? Redirect { get; private set; }

    /// <summary>
    /// 可选。别名，访问 `/home` 时会匹配 `/` 的路由。
    /// </summary>
    public string? Alias { get; private set; }

    /// <summary>
    /// 是否隐藏该路由。如果为 true，则该路由不会显示在菜单中。
    /// </summary>
    public bool? Hidden { get; private set; }

    /// <summary>
    /// 是否始终显示根菜单。如果为 true，即使只有一个子路由，也会显示父级菜单。
    /// </summary>
    public bool? AlwaysShow { get; private set; }

    /// <summary>
    /// 路由标题，通常用于菜单或标签页显示。
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// 权限前端图标
    /// </summary>
    public string? Icon { get; private set; }

    /// <summary>
    /// 是否禁用页面缓存。如果为 true，则该页面不会被缓存。
    /// </summary>
    public bool? NoCache { get; private set; }

    /// <summary>
    /// 是否显示面包屑导航。如果为 false，则该路由不会出现在面包屑中。
    /// </summary>
    public bool? Breadcrumb { get; private set; }

    /// <summary>
    /// 是否固定在标签页中。如果为 true，则该路由会始终显示在标签页中。
    /// </summary>
    public bool? Affix { get; private set; }

    /// <summary>
    /// 当前路由激活时，需要高亮的菜单项路径。
    /// </summary>
    public string? ActiveMenu { get; private set; }

    /// <summary>
    /// 是否禁用标签页视图。如果为 true，则该路由不会显示在标签页中。
    /// </summary>
    public bool? NoTagsView { get; private set; }

    /// <summary>
    /// 是否允许跳转到该路由。如果为 false，则无法通过编程式导航跳转到该路由。
    /// </summary>
    public bool? CanTo { get; private set; }
}