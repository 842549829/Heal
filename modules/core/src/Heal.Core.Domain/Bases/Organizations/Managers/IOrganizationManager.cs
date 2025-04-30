namespace Heal.Core.Domain.Bases.Organizations.Managers;

/// <summary>
/// 组织管理器
/// </summary>
public interface IOrganizationManager : IHealCoreDomainManager
{
    /// <summary>
    /// 获取组织Id
    /// </summary>
    /// <param name="organizationCode">组织Code</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织Id</returns>
    Task<Guid> GetOrganizationIdAsync(string organizationCode, CancellationToken cancellationToken = default);
}