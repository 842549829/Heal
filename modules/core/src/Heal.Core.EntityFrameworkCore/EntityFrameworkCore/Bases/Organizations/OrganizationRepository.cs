using Heal.Core.Domain.Bases.Organizations.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Organizations;

/// <summary>
/// 组织机构仓储
/// </summary>
public class OrganizationRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider)
    : EfCoreOrganizationUnitRepository(dbContextProvider), IOrganizationRepository
{
    /// <summary>
    /// 根据组织机构代码获取组织机构Id
    /// </summary>
    /// <param name="organizationCode">组织机构代码</param>
    /// <param name="cancellationToken">取消Token</param>
    /// <returns>组织机构Id</returns>
    public async Task<Guid> GetOrganizationIdAsync(string organizationCode, CancellationToken cancellationToken = default)
    {
        var context = await GetDbContextAsync();
        return await context.OrganizationUnits.Where(a => a.Code == organizationCode)
            .Select(a => a.Id)
            .FirstAsync(cancellationToken);
    }
}