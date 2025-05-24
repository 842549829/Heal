namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 用户常量
/// </summary>
public static class UserConstants
{
    /// <summary>
    /// 用户名最大长度
    /// </summary>
    public static int MaxUserNameLength { get; set; } = 32;

    /// <summary>
    /// 性别最大长度
    /// </summary>
    public static int MaxGenderLength { get; set; } = 16;

    /// <summary>
    /// 电话最大长度
    /// </summary>
    public static int MaxPhoneLength { get; set; } = 32;

    /// <summary>
    /// 邮箱最大长度
    /// </summary>
    public static int MaxEmailLength { get; set; } = 64;
}