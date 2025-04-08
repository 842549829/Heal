namespace Heal.Domain.Entities;

/// <summary>
/// 可描述
/// </summary>
public interface IMayHaveDescribe
{
    /// <summary>
    /// 描述
    /// </summary>
    string? Describe { get; }
}