using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;

namespace Heal.Net.Domain.Bases.Roles.Repositories;

/// <summary>
/// 角色扩展仓储
/// </summary>

public interface IRoleExtensionRepository : ITransientDependency
{
    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="roles">角色</param>
    /// <returns>角色</returns>
    Task<List<IdentityRole>> GetRoleAsync(string[] roles);
}