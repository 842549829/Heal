namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可有描述
/// </summary>
public interface IMayHaveDescribeDto
{
    /// <summary>
    /// 描述
    /// </summary>
    string? Describe { get; }
}