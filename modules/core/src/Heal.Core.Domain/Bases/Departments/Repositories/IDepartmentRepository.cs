using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace Heal.Core.Domain.Bases.Departments.Repositories;

/// <summary>
/// 科室仓储接口
/// </summary>
public interface IDepartmentRepository : IHealRepository, IBasicRepository<Department, Guid>
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
    Task<List<Department>> GetListAsync(
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string? filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
    
    /// <summary>
    /// 获取科室总数
    /// </summary>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室总数</returns>
    Task<long> GetCountAsync(
        string? filter = null,
        CancellationToken cancellationToken = default
    );
}