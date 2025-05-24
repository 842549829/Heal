using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Core.Domain.Bases.Departments.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Departments;

/// <summary>
/// 科室仓储
/// </summary>
/// <param name="dbContextProvider">dbContext</param>
public class DepartmentRepository(IDbContextProvider<IHealCoreDbContext> dbContextProvider)
    : EfCoreRepository<IHealCoreDbContext, Department, Guid>(dbContextProvider), IDepartmentRepository
{
    /// <summary>
    /// 获取科室列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="includeDetails">是否启用导航属性查询</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    public async Task<List<Department>> GetListAsync(string? sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string? filter = null,
        bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.Code.StartsWith(filter!))
            .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(Department.CreationTime) + " desc" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    /// <summary>
    /// 获取科室总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室总数</returns>
    public async Task<long> GetCountAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.Code.StartsWith(filter!))
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }
}