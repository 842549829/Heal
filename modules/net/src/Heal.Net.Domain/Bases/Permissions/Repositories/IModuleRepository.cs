using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Repositories;

/// <summary>
/// 模块仓库
/// </summary>
public interface IModuleRepository : IHealRepository, IBasicRepository<PermissionGroupDefinitionRecord, Guid>
{
    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>列表</returns>
    Task<List<PermissionGroupDefinitionRecord>> GetListAsync(
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string? filter = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// 获取模块总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>总数</returns>
    Task<long> GetCountAsync(
        string? filter = null,
        CancellationToken cancellationToken = default
    );
}