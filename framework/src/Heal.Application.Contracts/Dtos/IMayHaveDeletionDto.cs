namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可删除
/// </summary>
public interface IMayHaveDeletionDto
{
    /// <summary>
    /// 删除人Id
    /// </summary>
    Guid? DeleterId { get; }
}