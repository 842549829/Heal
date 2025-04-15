namespace Heal.Domain.Entities;

/// <summary>
/// 组织实体扩展
/// </summary>
public interface IHasOrganizationExtension : IHasOrganization, IHasOrganizationCode
{
    /// <summary>
    /// 设置组织信息
    /// </summary>
    /// <param name="organizationId">组织Id</param>
    /// <param name="organizationCode">组织编码</param>
    public void SetOrganization(Guid organizationId, string organizationCode);
}