using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace Heal.Core.Domain.Bases.Campuses.Repositories;

/// <summary>
/// 院区仓储接口
/// </summary>
public interface ICampusRepository : IHealRepository, IBasicRepository<Campus, Guid>
{
    /// <summary>
    /// 获取院区列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="includeDetails">是否启用导航属性查询</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    Task<List<Campus>> GetListAsync(
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string? filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
    
    /// <summary>
    /// 获取院区总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区总数</returns>
    Task<long> GetCountAsync(
        string? filter = null,
        CancellationToken cancellationToken = default
    );
}