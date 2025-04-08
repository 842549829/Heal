namespace Heal.Domain.Entities;

/// <summary>
/// 证件扩展接口
/// </summary>
public interface IHasIdCardExtension : IHasIdCard
{
    /// <summary>
    /// 设置证件信息
    /// </summary>
    /// <param name="idCardType">证件类型</param>
    /// <param name="idCardNo">证件号</param>
    public void SetIdCard(string idCardType, string idCardNo);
}