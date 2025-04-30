using Heal.Core.Domain.Bases.Organizations.Models;
using Heal.Domain.Repositories;
using Volo.Abp.Identity;

namespace Heal.Core.Domain.Bases.Organizations.Repositories;

/// <summary>
/// 组织机构数据仓储(Dapper)
/// </summary>
public interface IOrganizationDapperRepository : IHealRepository
{
    /// <summary>
    /// 获取组织机构数量
    /// </summary>
    /// <param name="filter">关键词</param>
    /// <param name="parentId">父级Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数量</returns>
    Task<long> GetCountAsync(string? filter = null,
        Guid? parentId = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="filter">关键词</param>
    /// <param name="parentId">父级Id</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="includeDetails">是否加载子对象</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>组织机构列表</returns>
    Task<List<OrganizationUnit>> GetListAsync(
        string? sorting,
        string? filter = null,
        Guid? parentId = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="parentIds">父级Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>组织机构树节点</returns>
    Task<List<OrganizationWithChildCount>> GetOrganizationUnitsWithChildCountAsync(List<Guid> parentIds,
        CancellationToken cancellationToken = default);
}