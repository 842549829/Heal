namespace Heal.Domain.Modules;

/// <summary>
/// 带分页、排序、过滤条件的输入
/// </summary>
public class PagedAndSortedAndFilterInput : PagedAndSortedInput
{
    /// <summary>
    /// 过滤条件
    /// </summary>
    public string? Filter { get; set; }
}