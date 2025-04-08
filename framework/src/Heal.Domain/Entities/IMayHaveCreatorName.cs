namespace Heal.Domain.Entities;

/// <summary>
/// 创建人名称
/// </summary>
public interface IMayHaveCreatorName 
{
    /// <summary>
    /// 创建人名称
    /// </summary>
    string? CreatorName { get; }
}