using Heal.Dict.Domain.Dictes.Entities;
using Heal.Domain.Modules;
using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace Heal.Dict.Domain.Dictes.Repositories;

/// <summary>
/// 字典类型
/// </summary>
public interface IDictTypeRepository : IHealRepository, IBasicRepository<DictType, Guid>
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>(总条数,当前页数据)</returns>
    Task<(long, List<DictType>)> GetListAsync(PagedAndSortedAndFilterInput input, CancellationToken cancellationToken = default);
}