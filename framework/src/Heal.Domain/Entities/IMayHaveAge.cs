namespace Heal.Domain.Entities;

/// <summary>
/// 允许设置年龄的扩展接口
/// </summary>
public interface IMayHaveAge
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