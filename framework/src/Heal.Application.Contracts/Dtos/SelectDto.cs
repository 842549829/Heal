namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 下拉选择框
/// </summary>
public class SelectDto : IHasSelectDto
{
    /// <summary>
    /// 标签
    /// </summary>
    public required string Label { get; init; }

    /// <summary>
    /// 值
    /// </summary>
    public required string Value { get; init; }
}