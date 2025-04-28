namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 过滤输入
/// </summary>
public interface IFilterInput
{
    /// <summary>
    /// 过滤条件
    /// </summary>
    public string? Filter { get; }
}