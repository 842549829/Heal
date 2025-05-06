namespace Heal.Domain.Modules;

/// <summary>
/// 分页和排序输入
/// </summary>
public class PagedAndSortedInput : PageInput
{
    /// <summary>
    /// 排序字段
    /// </summary>
    public string? Sorting { get; set; }
}