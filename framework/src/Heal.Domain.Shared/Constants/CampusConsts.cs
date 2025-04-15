namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 院区常量
/// </summary>
public static class CampusConsts
{
    /// <summary>
    /// 院区标识
    /// </summary>
    public const string Code = "Campus";

    /// <summary>
    /// 院区简称最大长度
    /// </summary>
    public static int MaxShortNameLength { get; set; } = 32;

    /// <summary>
    /// 所在大楼最大长度
    /// </summary>
    public static int MaxBuildingLength { get; set; } = 64;

    /// <summary>
    /// 所在楼层最大长度
    /// </summary>
    public static int MaxFloorLength { get; set; } = 16;

    /// <summary>
    /// 房间号最大长度
    /// </summary>
    public static int MaxRoomNumberLength { get; set; } = 16;

    /// <summary>
    /// 所在详细地址最大长度
    /// </summary>
    public static int MaxAddressLength { get; set; } = 256;

    /// <summary>
    /// 联系电话最大长度
    /// </summary>
    public static int MaxPhoneLength { get; set; } = 32;

    /// <summary>
    /// 电子邮箱最大长度
    /// </summary>
    public static int MaxEmailLength { get; set; } = 128;

    /// <summary>
    /// 院区负责人最大长度
    /// </summary>
    public static int MaxHeadOfCampusLength { get; set; } = 64;

    /// <summary>
    /// 负责人电话最大长度
    /// </summary>
    public static int MaxHeadOfCampusPhoneLength { get; set; } = 32;

    /// <summary>
    /// 负责人电子邮箱最大长度
    /// </summary>
    public static int MaxHeadOfCampusEmailLength { get; set; } = 128;

    /// <summary>
    /// 院区网站最大长度
    /// </summary>
    public static int MaxWebsiteLength { get; set; } = 256;

    /// <summary>
    /// 提供的服务最大长度
    /// </summary>
    public static int MaxServicesOfferedLength { get; set; } = 512;

    /// <summary>
    /// 紧急联系人最大长度
    /// </summary>
    public static int MaxEmergencyContactLength { get; set; } = 64;

    /// <summary>
    /// 紧急联系电话最大长度
    /// </summary>
    public static int MaxEmergencyPhoneLength { get; set; } = 32;
}