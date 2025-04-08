
namespace Heal.Domain.Entities;

/// <summary>
/// 带排序的实体
/// </summary>
public interface IHasSort
{
    /// <summary>
    /// 排序
    /// </summary>
    int Sort { get; }
}