﻿namespace Heal.Domain.Entities;

/// <summary>
/// 可能拥有地址
/// </summary>
public interface IMayHaveAddress
{
    /// <summary>
    /// 国家代码
    /// </summary>
    public string? NationCode { get; }

    /// <summary>
    /// 省份代码
    /// </summary>
    public string? ProvinceCode { get; }

    /// <summary>
    /// 城市代码
    /// </summary>
    public string? CityCode { get; }

    /// <summary>
    /// 区域代码
    /// </summary>
    public string? DistrictCode { get; }

    /// <summary>
    /// 街道
    /// </summary>
    public string? Street { get; }

    /// <summary>
    /// 详细地址
    /// </summary>
    public string? AddressLine { get; }
}