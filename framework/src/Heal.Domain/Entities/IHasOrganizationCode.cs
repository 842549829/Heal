namespace Heal.Domain.Entities;

/// <summary>
/// 组织编码
/// </summary>
public interface IHasOrganizationCode
{
    /// <summary>
    /// 组织编码
    /// </summary>
    string OrganizationCode { get; }
}