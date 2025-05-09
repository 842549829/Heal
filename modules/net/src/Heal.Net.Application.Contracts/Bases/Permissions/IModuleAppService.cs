﻿using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 模块应用服务
/// </summary>
public interface IModuleAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task CeateAsync(ModuleCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    Task UpdateAsync(Guid id, ModuleUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 模块列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    Task<PagedResultDto<ModuleListDto>> GetListAsync(ModuleInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 模块详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>详情</returns>
    Task<ModuleDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
}