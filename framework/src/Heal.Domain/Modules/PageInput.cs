namespace Heal.Domain.Modules;

/// <summary>
/// 分页输入
/// </summary>
public class PageInput
{
    /// <summary>
    /// 跳过数量
    /// </summary>
    public int SkipCount { get; set; } 

    /// <summary>
    /// 每页最大数量
    /// </summary>
    public int MaxResultCount { get; set; } = int.MaxValue;
}