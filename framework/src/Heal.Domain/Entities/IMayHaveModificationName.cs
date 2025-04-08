namespace Heal.Domain.Entities;

/// <summary>
/// 可修改修改人名称
/// </summary>
public interface IMayHaveModificationName
{
    /// <summary>
    /// 修改人名称
    /// </summary>
    string? LastModificationName { get; }
}