namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 证件相关常量
/// </summary>
public static class IdCardConsts
{
    /// <summary>
    /// 身份证
    /// </summary>
    public const string IdCardType01 = "01";

    /// <summary>
    /// 证件号最大长度
    /// </summary>
    public static int MaxIdCardNoLength { get; set; } = 32;

    /// <summary>
    /// 证件类型最大长度
    /// </summary>
    public static int MaxIdCardTypeLength { get; set; } = 16;
}