using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.Domain.Dictes.Repositories;
using Heal.Domain.Modules;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore.Dictes;

/// <summary>
/// 字典项仓储
/// </summary>
/// <param name="dbContextProvider">IHealDictDbContext</param>
public class DictTypeRepository(IDbContextProvider<IHealDictDbContext> dbContextProvider)
    : EfCoreRepository<IHealDictDbContext, DictType, Guid>(dbContextProvider), IDictTypeRepository
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>(总条数,当前页数据)</returns>
    public async Task<(long, List<DictType>)> GetListAsync(PagedAndSortedAndFilterInput input, CancellationToken cancellationToken = default)
    {
        var db = await GetDbSetAsync();

        var query = db
            .WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(input.Filter!) ||
                     x.Code.StartsWith(input.Filter!));

        var count = await query
            .LongCountAsync(GetCancellationToken(cancellationToken));

        var list = await query
            .OrderBy(input.Sorting.IsNullOrWhiteSpace() ? nameof(DictType.CreationTime) + " desc" : input.Sorting)
            .PageBy(input.SkipCount, input.MaxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));

        return (count, list);
    }
}