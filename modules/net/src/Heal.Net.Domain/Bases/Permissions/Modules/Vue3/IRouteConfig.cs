namespace Heal.Net.Domain.Bases.Permissions.Modules.Vue3;

/// <summary>
/// 路由配置
/// </summary>
public interface IRouteConfig : IMeta
{
    /// <summary>
    /// 必填。路由路径，支持动态参数和通配符。
    /// </summary>
    public string Path { get; }

    /// <summary>
    /// 可选。路由名称，用于编程式导航（如 router.push({ name: 'Home' })）。
    /// </summary>
    public string? Name { get; }

    /// <summary>
    /// 必填。与该路由对应的组件。
    /// </summary>
    public string Component { get; }

    /// <summary>
    /// 可选。重定向到另一个路径（可以是字符串或函数）。
    /// </summary>
    public string? Redirect { get; }

    /// <summary>
    /// 可选。别名，访问 `/home` 时会匹配 `/` 的路由。
    /// </summary>
    public string? Alias { get; }
}