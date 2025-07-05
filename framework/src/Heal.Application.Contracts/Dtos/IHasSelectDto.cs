namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 筛选
/// </summary>
public interface IHasSelectDto
{
    /// <summary>
    /// 标签
    /// </summary>
    string Label { get; }

    /// <summary>
    /// 值
    /// </summary>
    string Value { get; }
}