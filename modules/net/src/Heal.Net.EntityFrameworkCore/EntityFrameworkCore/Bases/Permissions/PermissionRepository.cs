using Heal.Net.Domain.Bases.Permissions.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Permissions;

/// <summary>
/// PermissionRepository
/// </summary>
/// <param name="dbContextProvider">dbContextProvider</param>
public class PermissionRepository(IDbContextProvider<IPermissionManagementDbContext> dbContextProvider)
    : EfCoreRepository<IPermissionManagementDbContext, PermissionGrant, Guid>(dbContextProvider), IPermissionRepository
{
    /// <summary>
    /// 获取权限列表
    /// </summary>
    /// <param name="providerName">providerName</param>
    /// <param name="providerKey">providerKey</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>权限</returns>
    public async Task<List<PermissionGrant>> GetPermissionListAsync(string providerName, string[] providerKey, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .Where(s =>
                s.ProviderName == providerName &&
                providerKey.Contains(s.ProviderKey)
            )
            .Distinct()
            .ToListAsync(GetCancellationToken(cancellationToken));
    }
}