using Heal.Net.Domain.Bases.Permissions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Permissions;

/// <summary>
/// 菜单
/// </summary>
/// <param name="dbContextProvider">dbContextProvider</param>
public class MenuRepository(IDbContextProvider<IPermissionManagementDbContext> dbContextProvider)
    : EfCoreRepository<IPermissionManagementDbContext, PermissionDefinitionRecord, Guid>(dbContextProvider), IMenuRepository
{
    /// <summary>
    /// 获取Menu列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>列表</returns>
    public async Task<List<PermissionDefinitionRecord>> GetListAsync(string? sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string? filter = null,
        CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.DisplayName.StartsWith(filter!))
            .OrderBy(sorting.IsNullOrWhiteSpace() ? nameof(PermissionDefinitionRecord.Id) + " desc" : sorting)
            .PageBy(skipCount, maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    /// <summary>
    /// 获取Menu总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>总数</returns>
    public async Task<long> GetCountAsync(string? filter = null, CancellationToken cancellationToken = default)
    {
        return await (await GetDbSetAsync())
            .WhereIf(!filter.IsNullOrWhiteSpace(),
                x => x.Name.StartsWith(filter!) ||
                     x.DisplayName.StartsWith(filter!))
            .LongCountAsync(GetCancellationToken(cancellationToken));
    }
}