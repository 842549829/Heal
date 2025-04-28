using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 菜单服务
/// </summary>
public interface IMenuAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task CeateAsync(MenuCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task UpdateAsync(Guid id, MenuUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 菜单列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    Task<PagedResultDto<MenuListDto>> GetListAsync(MenuInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 菜单详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>详情</returns>
    Task<MenuDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
}