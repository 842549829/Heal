using Volo.Abp.Identity;

namespace Heal.Core.Domain.Bases.Organizations.Repositories;

/// <summary>
/// 组织机构仓储
/// </summary>
public interface IOrganizationRepository : IOrganizationUnitRepository
{
    /// <summary>
    /// 根据组织机构代码获取组织机构Id
    /// </summary>
    /// <param name="organizationCode">组织机构代码</param>
    /// <param name="cancellationToken">取消Token</param>
    /// <returns>组织机构Id</returns>
    Task<Guid> GetOrganizationIdAsync(string organizationCode, CancellationToken cancellationToken = default);
}