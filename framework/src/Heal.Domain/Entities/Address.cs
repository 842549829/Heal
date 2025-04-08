namespace Heal.Domain.Entities;

/// <summary>
/// 可能拥有地址
/// </summary>
/// <param name="NationCode">国家代码</param>
/// <param name="ProvinceCode">省份代码</param>
/// <param name="CityCode">城市代码</param>
/// <param name="DistrictCode">区域代码</param>
/// <param name="Street">街道</param>
/// <param name="AddressLine">详细地址</param>
public record Address(string? NationCode, string? ProvinceCode, string? CityCode, string? DistrictCode, string? Street, string? AddressLine) : IMayHaveAddress;