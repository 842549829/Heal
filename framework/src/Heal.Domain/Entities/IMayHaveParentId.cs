namespace Heal.Domain.Entities;

/// <summary>
/// 可有父级Id
/// </summary>
public interface IMayHaveParentId
{
    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; }
}