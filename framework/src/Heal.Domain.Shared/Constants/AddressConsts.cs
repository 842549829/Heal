namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 地址常量
/// </summary>
public static class AddressConsts
{
    /// <summary>
    /// 国家代码最大长度
    /// </summary>
    public static int MaxNationCodeLength { get; set; } = 16;

    /// <summary>
    /// 省份代码最大长度
    /// </summary>
    public static int MaxProvinceCodeLength { get; set; } = 16;

    /// <summary>
    /// 城市代码最大长度
    /// </summary>
    public static int MaxCityCodeLength { get; set; } = 16;

    /// <summary>
    /// 区域代码最大长度
    /// </summary>
    public static int MaxDistrictCodeLength { get; set; } = 16;

    /// <summary>
    /// 街道最大长度
    /// </summary>
    public static int MaxStreetLength { get; set; } = 64;

    /// <summary>
    /// 地址行最大长度
    /// </summary>
    public static int MaxAddressLineLength { get; set; } = 128;
}