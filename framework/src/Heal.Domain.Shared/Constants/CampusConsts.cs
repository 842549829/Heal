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
    /// 院区标识默认长度
    /// </summary>
    public const int CodeDefaultLength = 5;

    /// <summary>
    /// 院区简称最大长度
    /// </summary>
    public const int ShortNameMaxLength = 32;

    /// <summary>
    /// 所在大楼最大长度
    /// </summary>
    public const int BuildingMaxLength = 64;

    /// <summary>
    /// 所在楼层最大长度
    /// </summary>
    public const int FloorMaxLength = 16;

    /// <summary>
    /// 房间号最大长度
    /// </summary>
    public const int RoomNumberMaxLength = 16;

    /// <summary>
    /// 所在详细地址最大长度
    /// </summary>
    public const int AddressMaxLength = 256;

    /// <summary>
    /// 联系电话最大长度
    /// </summary>
    public const int PhoneMaxLength = 32;

    /// <summary>
    /// 电子邮箱最大长度
    /// </summary>
    public const int EmailMaxLength = 128;

    /// <summary>
    /// 院区负责人最大长度
    /// </summary>
    public const int HeadOfCampusMaxLength = 64;

    /// <summary>
    /// 负责人电话最大长度
    /// </summary>
    public const int HeadOfCampusPhoneMaxLength = 32;

    /// <summary>
    /// 负责人电子邮箱最大长度
    /// </summary>
    public const int HeadOfCampusEmailMaxLength = 128;

    /// <summary>
    /// 院区网站最大长度
    /// </summary>
    public const int WebsiteMaxLength = 256;

    /// <summary>
    /// 提供的服务最大长度
    /// </summary>
    public const int ServicesOfferedMaxLength = 512;

    /// <summary>
    /// 紧急联系人最大长度
    /// </summary>
    public const int EmergencyContactMaxLength = 64;

    /// <summary>
    /// 紧急联系电话最大长度
    /// </summary>
    public const int EmergencyPhoneMaxLength = 32;
}