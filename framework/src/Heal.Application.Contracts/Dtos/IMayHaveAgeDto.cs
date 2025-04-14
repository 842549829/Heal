namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可有年龄
/// </summary>
public interface IMayHaveAgeDto
{
    /// <summary>
    /// 岁
    /// </summary>
    int? Year { get; }

    /// <summary>
    /// 月
    /// </summary>
    int? Month { get; }

    /// <summary>
    /// 天
    /// </summary>
    int? Day { get; }
}