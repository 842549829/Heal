namespace Heal.Domain.Entities;

/// <summary>
/// 允许设置年龄的扩展接口
/// </summary>
public interface IMayHaveAgeExtension : IMayHaveAge
{
    /// <summary>
    /// 设置年龄
    /// </summary>
    /// <param name="year">年</param>
    /// <param name="month">月</param>
    /// <param name="day">天</param>
    public void SetAge(int? year, int? month, int? day);
}