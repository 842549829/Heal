namespace Heal.Domain.Entities;

/// <summary>
/// 删除人名称
/// </summary>
public interface IMayHaveDeletionName
{
    /// <summary>
    /// 删除人名称
    /// </summary>
    string? DeletionName { get; }
}