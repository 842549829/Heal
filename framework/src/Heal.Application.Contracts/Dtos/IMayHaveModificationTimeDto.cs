namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 修改时间
/// </summary>
public interface IMayHaveModificationTimeDto
{
    /// <summary>
    /// 最后修改时间
    /// </summary>
    DateTime? LastModificationTime { get; }
}