namespace Heal.Domain.Entities;

/// <summary>
/// 证件信息接口
/// </summary>
public interface IHasIdCard
{
    /// <summary>
    /// 证件类型
    /// </summary>
    public string IdCardType { get; }

    /// <summary>
    /// 证件号
    /// </summary>
    public string IdCardNo { get; }
}