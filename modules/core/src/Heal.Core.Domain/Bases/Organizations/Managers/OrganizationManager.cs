using Heal.Core.Domain.Bases.Organizations.Repositories;

namespace Heal.Core.Domain.Bases.Organizations.Managers;

/// <summary>
/// 组织管理
/// </summary>
/// <param name="organizationRepository">组织仓储</param>
public class OrganizationManager(IOrganizationRepository organizationRepository) : HealCoreDomainManager, IOrganizationManager
{
    /// <summary>
    /// 获取组织Id
    /// </summary>
    /// <param name="organizationCode">组织Code</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织Id</returns>
    public Task<Guid> GetOrganizationIdAsync(string organizationCode, CancellationToken cancellationToken = default)
    {
        return organizationRepository.GetOrganizationIdAsync(organizationCode, cancellationToken);
    }
}