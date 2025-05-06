using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.Application.Contracts.Dictes;

/// <summary>
/// 字典项
/// </summary>
public interface IDictItemAppService : IHealDictApplicationService
{
    /// <summary>
    /// 获取字典项列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项列表</returns>
    Task<PagedResultDto<DictItemDto>> GetListAsync(GetDictItemInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 创建字典项
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    Task<DictItemDto> CreateAsync(DictItemCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    Task<DictItemDto> UpdateAsync(Guid id, DictItemUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 删除字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    Task<DictItemDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
