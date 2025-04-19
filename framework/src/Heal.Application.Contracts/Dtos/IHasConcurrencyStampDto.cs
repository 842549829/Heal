namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 迸发标记接口
/// </summary>
public interface IHasConcurrencyStampDto
{
    /// <summary>
    /// 迸发标记
    /// </summary>
    string ConcurrencyStamp { get; }
}