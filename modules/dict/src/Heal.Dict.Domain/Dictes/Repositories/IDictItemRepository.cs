using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.Domain.Dictes.Modules;
using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;

namespace Heal.Dict.Domain.Dictes.Repositories;

/// <summary>
/// 字典项仓储
/// </summary>
public interface IDictItemRepository : IHealRepository, IBasicRepository<DictItem, Guid>
{
    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>(总条数,当前页数据)</returns>
    Task<(long, List<DictItem>)> GetListAsync(DictItemInput input, CancellationToken cancellationToken = default);
}