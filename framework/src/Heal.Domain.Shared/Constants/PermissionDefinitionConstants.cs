namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 权限定义常量
/// </summary>
public static class PermissionDefinitionConstants
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public const string PermissionName = "permissionName";

    /// <summary>
    /// 父级权限名称
    /// </summary>
    public const string ParentName = "parentName";

    /// <summary>
    /// 权限显示名称
    /// </summary>
    public const string DisplayName = "displayName";

    /// <summary>
    /// 权限类型
    /// </summary>
    public const string Type = "type";

    /// <summary>
    /// 标记
    /// </summary>
    public const string Tag = "tag";

    /// <summary>
    /// 子权限
    /// </summary>
    public const string ChildPermissions = "childPermissions";

    /// <summary>
    /// 权限前端路由
    /// </summary>
    public const string Path = "path";

    /// <summary>
    /// 可选。路由名称，用于编程式导航（如 router.push({ name: 'Home' })）。
    /// </summary>
    public const string Name = "name";

    /// <summary>
    /// 必填。与该路由对应的组件。
    /// </summary>
    public const string Component = "component";

    /// <summary>
    /// 可选。重定向到另一个路径（可以是字符串或函数）。
    /// </summary>
    public const string Redirect = "redirect";

    /// <summary>
    /// 可选。别名，访问 `/home` 时会匹配 `/` 的路由。
    /// </summary>
    public const string Alias = "alias";

    /// <summary>
    /// 是否隐藏该路由。如果为 true，则该路由不会显示在菜单中。
    /// </summary>
    public const string Hidden = "hidden";

    /// <summary>
    /// 是否始终显示根菜单。如果为 true，即使只有一个子路由，也会显示父级菜单。
    /// </summary>
    public const string AlwaysShow = "alwaysShow";

    /// <summary>
    /// 路由标题，通常用于菜单或标签页显示。
    /// </summary>
    public const string Title = "title";

    /// <summary>
    /// 权限前端图标
    /// </summary>
    public const string Icon = "icon";

    /// <summary>
    /// 是否禁用页面缓存。如果为 true，则该页面不会被缓存。
    /// </summary>
    public const string NoCache = "noCache";

    /// <summary>
    /// 是否显示面包屑导航。如果为 false，则该路由不会出现在面包屑中。
    /// </summary>
    public const string Breadcrumb = "breadcrumb";

    /// <summary>
    /// 是否固定在标签页中。如果为 true，则该路由会始终显示在标签页中。
    /// </summary>
    public const string Affix = "affix";

    /// <summary>
    /// 当前路由激活时，需要高亮的菜单项路径。
    /// </summary>
    public const string ActiveMenu = "activeMenu";

    /// <summary>
    /// 是否禁用标签页视图。如果为 true，则该路由不会显示在标签页中。
    /// </summary>
    public const string NoTagsView = "noTagsView";

    /// <summary>
    /// 是否允许跳转到该路由。如果为 false，则无法通过编程式导航跳转到该路由。
    /// </summary>
    public const string CanTo = "canTo";
}