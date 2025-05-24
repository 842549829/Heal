using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Regions;

/// <summary>
/// 地区
/// </summary>
/// <typeparam name="TKey">TKey</typeparam>
public abstract class BaseRegion<TKey> : HealthcareAuditedAggregateRoot<TKey>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="version">版本</param>
    /// <param name="parentCode">上级编码</param>
    protected BaseRegion(TKey id, 
        string name, 
        string code, 
        string version, 
        string parentCode) : base(id, name, code)
    {
        Version = version;
        ParentCode = parentCode;
    }
    
    /// <summary>
    /// 上级编码
    /// </summary>
    public virtual string ParentCode { get; private set; }
    
    /// <summary>
    /// 设置上级编码
    /// </summary>
    /// <param name="parentCode">上级编码</param>
    public virtual void SetParentCode(string parentCode)
    {
        ParentCode = parentCode;
    }
    
    /// <summary>
    /// 版本
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// 设置版本
    /// </summary>
    /// <param name="version">版本</param>
    public void SetVersion(string version)
    {
        Version = version;
    }
    
    /// <summary>
    /// 经度
    /// </summary>
    public decimal? Longitude { get; private set; }
    
    /// <summary>
    /// 纬度
    /// </summary>
    public decimal? Latitude { get; private set; }
    
    /// <summary>
    /// 设置经纬度
    /// </summary>
    /// <param name="longitude">经度</param>
    /// <param name="latitude">纬度</param>
    public void SetLocation(decimal? longitude, decimal? latitude)
    {
        Longitude = longitude;
        Latitude = latitude;
    }
    
    /// <summary>
    /// 邮政编码
    /// </summary>
    public string? PostalCode { get; private set; }
    
    /// <summary>
    /// 设置邮政编码
    /// </summary>
    /// <param name="postalCode">邮政编码</param>
    public void SetPostalCode(string? postalCode)
    {
        PostalCode = postalCode;
    }
}