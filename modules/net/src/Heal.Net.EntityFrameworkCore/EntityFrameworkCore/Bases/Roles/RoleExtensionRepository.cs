using Heal.Net.Domain.Bases.Roles.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Roles;

/// <summary>
/// 角色扩展
/// </summary>
/// <param name="dbContextProvider">IDbContextProvider</param>
public class RoleExtensionRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider)
    : EfCoreIdentityRoleRepository(dbContextProvider), IRoleExtensionRepository
{
    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="roles">角色</param>
    /// <returns>角色</returns>
    public async Task<List<IdentityRole>> GetRoleAsync(string[] roles)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.Where(a => roles.Contains(a.NormalizedName))
            .ToListAsync();
    }
}