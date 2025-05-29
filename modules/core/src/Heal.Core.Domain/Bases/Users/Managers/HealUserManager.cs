using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Volo.Abp.Caching;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Settings;
using Volo.Abp.Threading;

namespace Heal.Core.Domain.Bases.Users.Managers;

/// <summary>
/// 用户管理
/// </summary>
/// <param name="store">用户仓库</param>
/// <param name="roleRepository">角色仓储</param>
/// <param name="userRepository">用户仓储</param>
/// <param name="optionsAccessor">用户配置</param>
/// <param name="passwordHasher">Hash密码</param>
/// <param name="userValidators">用户验证</param>
/// <param name="passwordValidators">密码验证</param>
/// <param name="keyNormalizer">规范化</param>
/// <param name="errors">错误描述</param>
/// <param name="services">服务Provider</param>
/// <param name="logger">日志</param>
/// <param name="cancellationTokenProvider">取消令牌Provider</param>
/// <param name="organizationUnitRepository">组织仓储</param>
/// <param name="settingProvider">配置Provide</param>
/// <param name="distributedEventBus">分布式事件</param>
/// <param name="identityLinkUserRepository">用户连接仓储</param>
/// <param name="dynamicClaimCache">动态缓存</param>
public class HealUserManager(
    IdentityUserStore store,
    IIdentityRoleRepository roleRepository,
    IIdentityUserRepository userRepository,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<IdentityUser> passwordHasher,
    IEnumerable<IUserValidator<IdentityUser>> userValidators,
    IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<IdentityUserManager> logger,
    ICancellationTokenProvider cancellationTokenProvider,
    IOrganizationUnitRepository organizationUnitRepository,
    ISettingProvider settingProvider,
    IDistributedEventBus distributedEventBus,
    IIdentityLinkUserRepository identityLinkUserRepository,
    IDistributedCache<AbpDynamicClaimCacheItem> dynamicClaimCache)
    : IdentityUserManager(store, roleRepository, userRepository, optionsAccessor, passwordHasher, userValidators,
        passwordValidators, keyNormalizer, errors, services, logger, cancellationTokenProvider,
        organizationUnitRepository, settingProvider, distributedEventBus, identityLinkUserRepository, dynamicClaimCache)
{
    /// <summary>
    /// 获取用户数量
    /// </summary>
    /// <param name="inputFilter">查询条件</param>
    /// <returns>用户数</returns>
    public Task<long> GetCountAsync(string inputFilter)
    {
        return UserRepository.GetCountAsync(inputFilter);
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="inputSorting">排序条件</param>
    /// <param name="inputMaxResultCount">最大条数</param>
    /// <param name="inputSkipCount">跳过条数</param>
    /// <param name="inputFilter">查询条件</param>
    /// <returns>用户列表</returns>
    public Task<List<IdentityUser>> GetListAsync(string? inputSorting, int inputMaxResultCount, int inputSkipCount, string? inputFilter)
    {
        return UserRepository.GetListAsync(inputSorting, inputMaxResultCount, inputSkipCount, inputFilter);
    }

    /// <summary>
    /// 获取用户角色
    /// </summary>
    /// <param name="id">用户Id</param>
    /// <returns>角色</returns>
    public Task<List<IdentityRole>> GetRolesAsync(Guid id)
    {
        return UserRepository.GetRolesAsync(id);
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>用户</returns>
    public Task<IdentityUser> GetAsync(Guid id)
    {
        return UserRepository.GetAsync(id);
    }


    //public virtual async Task AddToCampusAsync(IdentityUser user, Campus ou)
    //{
    //}

    //public virtual async Task AddToCampusAsync(Guid userId, Guid ouId)
    //{
    //}

    //public virtual async Task AddToDepartmentAsync(IdentityUser user, Campus ou)
    //{
    //}

    //public virtual async Task AddToDepartmentAsync(Guid userId, Guid ouId)
    //{
    //}
}