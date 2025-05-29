using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Volo.Abp.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Security.Claims;
using Volo.Abp.Threading;

namespace Heal.Core.Domain.Bases.Roles.Managers;

/// <summary>
/// 角色管理
/// </summary>
/// <param name="store">角色仓库</param>
/// <param name="roleValidators">角色验证</param>
/// <param name="keyNormalizer">规范化</param>
/// <param name="errors">错误描述</param>
/// <param name="logger">日志</param>
/// <param name="localizer">本地化</param>
/// <param name="cancellationTokenProvider">取消令牌Provider</param>
/// <param name="userRepository">用户仓储</param>
/// <param name="roleRepository">角色仓储</param>
/// <param name="organizationUnitRepository">组织仓储</param>
/// <param name="organizationUnitManager">组织管理</param>
/// <param name="dynamicClaimCache">动态缓存</param>
public class HealRoleManager(
    IdentityRoleStore store,
    IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    ILogger<IdentityRoleManager> logger,
    IStringLocalizer<IdentityResource> localizer,
    ICancellationTokenProvider cancellationTokenProvider,
    IIdentityUserRepository userRepository,
    IIdentityRoleRepository roleRepository,
    IOrganizationUnitRepository organizationUnitRepository,
    OrganizationUnitManager organizationUnitManager,
    IDistributedCache<AbpDynamicClaimCacheItem> dynamicClaimCache)
    : IdentityRoleManager(store, roleValidators, keyNormalizer, errors, logger, localizer, cancellationTokenProvider,
        userRepository, organizationUnitRepository, organizationUnitManager, dynamicClaimCache)
{
    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="sorting">排序条件</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">查询条件</param>
    /// <param name="includeDetails">是否加载导航属性</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>角色列表</returns>
    public Task<List<IdentityRole>> GetListAsync(string? sorting = null, int maxResultCount = int.MaxValue,
        int skipCount = 0, string? filter = null, bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        return roleRepository.GetListAsync(sorting, maxResultCount, skipCount, filter, includeDetails, cancellationToken);
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="ids">id集合</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>角色列表</returns>
    public Task<List<IdentityRole>> GetListAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        return roleRepository.GetListAsync(ids, cancellationToken);
    }

    /// <summary>
    /// 获取角色数量
    /// </summary>
    /// <param name="filter">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>角色数量</returns>
    public Task<long> GetCountAsync(string? filter = null, CancellationToken cancellationToken = default(CancellationToken))
    {
        return roleRepository.GetCountAsync(filter, cancellationToken);
    }
}