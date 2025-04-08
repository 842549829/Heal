namespace Heal.Domain.Entities;

/// <summary>
/// 允许设置年龄的扩展接口
/// </summary>
public interface IMayHaveAddressExtension : IMayHaveAddress
{
    /// <summary>
    /// 设置地址信息
    /// </summary>
    /// <param name="nationCode">国家代码</param>
    /// <param name="provinceCode">省份代码</param>
    /// <param name="cityCode">城市代码</param>
    /// <param name="districtCode">区域代码</param>
    /// <param name="street">街道</param>
    /// <param name="addressLine">详细地址</param>
    public void SetAddress(string nationCode, string provinceCode, string cityCode, string districtCode, string street,
        string addressLine);
}