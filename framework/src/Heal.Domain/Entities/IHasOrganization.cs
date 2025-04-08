namespace Heal.Domain.Entities;

/// <summary>
/// 组织实体扩展
/// </summary>
public interface IHasOrganization
{ 
    /// <summary>
    /// 组织Id
    /// </summary>
    Guid OrganizationId { get; }
}