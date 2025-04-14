namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 证件信息接口
/// </summary>
public interface IHasIdCardDto
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