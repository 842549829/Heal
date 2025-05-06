using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Core.Domain.Bases.Campuses.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;

/// <summary>
/// Repository
/// </summary>
/// <param name="dbContextProvider">IHealNetDbContext</param>
public class CampusRepository(IDbContextProvider<IHealCoreDbContext> dbContextProvider)
    : EfCoreRepository<IHealCoreDbContext, Campus, Guid>(dbContextProvider), ICampusRepository
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
    public async Task<List<Campus>> GetListAsync(string? sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string? filter = null,
        bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.Code.StartsWith(filter!))
            .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(Campus.CreationTime) + " desc" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    /// <summary>
    /// 获取院区总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区总数</returns>
    public async Task<long> GetCountAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.Code.StartsWith(filter!))
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }
}