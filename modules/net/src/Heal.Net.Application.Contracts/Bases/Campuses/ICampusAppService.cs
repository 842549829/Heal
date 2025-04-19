using Heal.Net.Application.Contracts.Bases.Campuses.Dto;

namespace Heal.Net.Application.Contracts.Bases.Campuses;

/// <summary>
/// 院区应用服务接口
/// </summary>
public interface ICampusAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>用户</returns>
    Task<CampusDto> CreateAsync(CampusCreateDto input, CancellationToken cancellationToken = default);
}