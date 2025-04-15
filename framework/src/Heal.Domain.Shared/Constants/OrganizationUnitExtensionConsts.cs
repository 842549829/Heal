namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 组织机构扩展常量
/// </summary>
public static class OrganizationUnitExtensionConsts
{
    /// <summary>
    /// 医院院长
    /// </summary>
    public const string Director = "Director";

    /// <summary>
    /// 医院等级
    /// </summary>
    public const string Level = "Level";

    /// <summary>
    /// 成立时间
    /// </summary>
    public const string EstablishmentDate = "EstablishmentDate";

    /// <summary>
    /// 联系电话
    /// </summary>
    public const string Phone = "Phone";

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public const string Email= "Email";

    /// <summary>
    /// 官方网站
    /// </summary>
    public const string WebsiteUrl = "WebsiteUrl";

    /// <summary>
    /// 地址
    /// </summary>
    public const string Address = "Address";

    /// <summary>
    /// 邮政编码
    /// </summary>
    public const string PostalCode = "PostalCode";

    /// <summary>
    /// 服务热线
    /// </summary>
    public const string ServiceHotline = "ServiceHotline";

    /// <summary>
    /// 医院简介
    /// </summary>
    public const string Introduction = "Introduction";

    /// <summary>
    /// 交通指南
    /// </summary>
    public const string TrafficGuide = "TrafficGuide";

    /// <summary>
    /// 停车信息
    /// </summary>
    public const string ParkingInformation = "ParkingInformation";

    /// <summary>
    /// 备注描述
    /// </summary>
    public const string Describe = "Describe";

    /// <summary>
    /// 纬度
    /// </summary>
    public const string Latitude = "Latitude";

    /// <summary>
    /// 经度
    /// </summary>
    public const string Longitude = "Longitude";

    /// <summary>
    /// 封面图片
    /// </summary>
    public const string CoverImage = "CoverImage";

    /// <summary>
    /// 营业时间
    /// </summary>
    public const string OperatingHours = "OperatingHours";

    /// <summary>
    /// 是否提供急诊服务
    /// </summary>
    public const string IsEmergencyServices = "IsEmergencyServices";

    /// <summary>
    /// 是否接受医保
    /// </summary>
    public const string IsInsuranceAccepted = "IsInsuranceAccepted";

    /// <summary>
    /// 医院设施
    /// </summary>
    public const string Facilities = "Facilities";

    /// <summary>
    /// 院长
    /// </summary>
    public static int MaxDirectorLength  { get; set; } = 64;

    /// <summary>
    /// 邮箱
    /// </summary>
    public static int MaxEmailLength { get; set; } = 64;

    /// <summary>
    /// 官网
    /// </summary>
    public static int MaxWebsiteUrlLength { get; set; } = 128;

    /// <summary>
    /// 地址
    /// </summary>
    public static int MaxAddressLength { get; set; } = 256;

    /// <summary>
    /// 邮政编码
    /// </summary>
    public static int MaxPostalCodeLength { get; set; } = 16;

    /// <summary>
    /// 服务热线
    /// </summary>
    public static int MaxServiceHotlineLength { get; set; } = 32;

    /// <summary>
    /// 医院简介
    /// </summary>
    public static int MaxIntroductionLength { get; set; } = 4096;

    /// <summary>
    /// 交通指南
    /// </summary>
    public static int MaxTrafficGuideLength { get; set; } = 512;

    /// <summary>
    /// 停车信息
    /// </summary>
    public static int MaxParkingInformationLength { get; set; } = 512;

    /// <summary>
    /// 备注描述
    /// </summary>
    public static int MaxDescribeLength { get; set; } = 512;

    /// <summary>
    /// 封面图片
    /// </summary>
    public static int MaxCoverImageLength { get; set; } = 1024;

    /// <summary>
    /// 医院设施
    /// </summary>
    public static int MaxFacilitiesLength { get; set; } = 1024;

    /// <summary>
    /// 组织默认长度
    /// </summary>
    public const int CodeDefaultLength = 5;
}