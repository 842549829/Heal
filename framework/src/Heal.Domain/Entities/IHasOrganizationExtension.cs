namespace Heal.Domain.Entities;

/// <summary>
/// 组织实体扩展
/// </summary>
public interface IHasOrganizationExtension : IHasOrganization
{
    /// <summary>
    /// 设置组织Id
    /// </summary>
    /// <param name="organizationId"></param>
    public void SetOrganization(Guid organizationId);
}