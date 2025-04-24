namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 模块首页列表信息
/// </summary>
public class ModuleHomeListDto
{
    /// <summary>
    /// 路由标题，通常用于菜单或标签页显示。
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    /// 菜单图标，通常是一个图标的名称或路径。
    /// </summary>
    public string? Icon { get; init; }

    /// <summary>
    /// 必填。路由路径，支持动态参数和通配符。
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    /// 可选。路由名称，用于编程式导航（如 router.push({ name: 'Home' })）。
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// 必填。与该路由对应的组件。
    /// </summary>
    public required string Component { get; init; }

    /// <summary>
    /// 可选。重定向到另一个路径（可以是字符串或函数）。
    /// </summary>
    public string? Redirect { get; init; }

    /// <summary>
    /// 可选。别名，访问 `/home` 时会匹配 `/` 的路由。
    /// </summary>
    public string? Alias { get; init; }
}