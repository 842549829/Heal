namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// Meta信息
/// </summary>
public class MetaDto
{
    /// <summary>
    /// 是否隐藏该路由。如果为 true，则该路由不会显示在菜单中。
    /// </summary>
    public bool? Hidden { get; init; }

    /// <summary>
    /// 是否始终显示根菜单。如果为 true，即使只有一个子路由，也会显示父级菜单。
    /// </summary>
    public bool? AlwaysShow { get; init; }

    /// <summary>
    /// 路由标题，通常用于菜单或标签页显示。
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// 权限前端图标
    /// </summary>
    public string? Icon { get; init; }

    /// <summary>
    /// 是否禁用页面缓存。如果为 true，则该页面不会被缓存。
    /// </summary>
    public bool? NoCache { get; init; }

    /// <summary>
    /// 是否显示面包屑导航。如果为 false，则该路由不会出现在面包屑中。
    /// </summary>
    public bool? Breadcrumb { get; init; }

    /// <summary>
    /// 是否固定在标签页中。如果为 true，则该路由会始终显示在标签页中。
    /// </summary>
    public bool? Affix { get; init; }

    /// <summary>
    /// 当前路由激活时，需要高亮的菜单项路径。
    /// </summary>
    public string? ActiveMenu { get; init; }

    /// <summary>
    /// 是否禁用标签页视图。如果为 true，则该路由不会显示在标签页中。
    /// </summary>
    public bool? NoTagsView { get; init; }

    /// <summary>
    /// 是否允许跳转到该路由。如果为 false，则无法通过编程式导航跳转到该路由。
    /// </summary>
    public bool? CanTo { get; init; }

    /// <summary>
    /// 权限
    /// </summary>
    public List<string>? Permission { get; set; }
}