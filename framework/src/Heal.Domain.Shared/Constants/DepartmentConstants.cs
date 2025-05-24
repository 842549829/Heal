namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 部门
/// </summary>
public static class DepartmentConstants
{
    /// <summary>
    /// 院区标识
    /// </summary>
    public const string Code = "Departments";
    
    /// <summary>
    /// 简称最大长度
    /// </summary>
    public static int MaxShortNameLength { get; set; } = 32;

    /// <summary>
    /// 名称最大长度
    /// </summary>
    public static int MaxNameLength { get; set; } = NameConstants.MaxLength;

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
    /// 部门负责人最大长度
    /// </summary>
    public static int MaxHeadOfDepartmentLength { get; set; } = 64;

    /// <summary>
    /// 部门负责人联系电话最大长度
    /// </summary>
    public static int MaxHeadOfDepartmentPhoneLength { get; set; } = 32;

    /// <summary>
    /// 部门负责人电子邮箱最大长度
    /// </summary>
    public static int MaxHeadOfDepartmentEmailLength { get; set; } = 128;

    /// <summary>
    /// 部门服务提供最大长度
    /// </summary>
    public static int MaxWebsiteLength { get; set; } = 256;

    /// <summary>
    /// 服务提供最大长度
    /// </summary>
    public static int MaxServicesOfferedLength { get; set; } = 512;

    /// <summary>
    /// 应急联系人最大长度
    /// </summary>
    public static int MaxEmergencyContactLength { get; set; } = 64;

    /// <summary>
    /// 应急联系人联系电话最大长度
    /// </summary>
    public static int MaxEmergencyPhoneLength { get; set; } = 32;
}