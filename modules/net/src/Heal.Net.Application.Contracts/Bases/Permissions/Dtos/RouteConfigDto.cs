namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 路由配置
/// </summary>
public class RouteConfigDto
{
    /// <summary>
    /// 权限前端路由
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

    /// <summary>
    /// 可选。路由元信息，用于传递任何你想传递的数据。
    /// </summary>
    public MetaDto? Meta { get; init; }

    /// <summary>
    /// 可选。子路由
    /// </summary>
    public List<RouteConfigDto>? Children { get; set; }
}