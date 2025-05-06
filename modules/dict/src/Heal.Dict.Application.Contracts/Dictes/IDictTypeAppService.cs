using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.Application.Contracts.Dictes;

/// <summary>
/// 字典类型
/// </summary>
public interface IDictTypeAppService : IHealDictApplicationService
{
    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    Task<PagedResultDto<DictTypeDto>> GetListAsync(GetDictTypeInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    Task<DictTypeDto> CreateAsync(DictTypeCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    Task<DictTypeDto> UpdateAsync(Guid id, DictTypeUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    Task<DictTypeDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
}