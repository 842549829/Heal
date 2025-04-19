using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses;

/// <summary>
/// 院区应用服务接口
/// </summary>
public interface ICampusAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建院区
    /// </summary>
    /// <param name="input">院区创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    Task<CampusDto> CreateAsync(CampusCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新院区
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="input">院区更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    Task<CampusDto> UpdateAsync(Guid id, CampusUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取院区列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区列表</returns>
    Task<PagedResultDto<CampusListDto>> GetListAsync(CampusInput input, CancellationToken cancellationToken = default);
}