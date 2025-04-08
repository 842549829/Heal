namespace Heal.Domain.Entities;

/// <summary>
/// 排序信息扩展
/// </summary>
public interface IHasSortExtension : IHasSort
{
    /// <summary>
    /// 设置排序信息
    /// </summary>
    /// <param name="sort">排序</param>
    void SetSort(int sort);
}