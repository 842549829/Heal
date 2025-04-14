namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 删除时间
/// </summary>
public interface IHasDeletionTimeDto
{
    /// <summary>
    /// 删除时间
    /// </summary>
    DateTime? DeletionTime { get; }
}