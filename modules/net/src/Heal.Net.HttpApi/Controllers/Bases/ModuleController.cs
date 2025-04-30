using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Application.Contracts.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 模块管理
/// </summary>
[ApiController]
[Route("api/net/basics/modules")]
public class ModuleController(IModuleAppService moduleAppService) : HealNetController
{
    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpPost]
    [Authorize(HealNetPermissions.Authorizations.Modules.Create)]
    public async Task CreateAsync([FromBody] ModuleCreateDto input, CancellationToken cancellationToken = default)
    {
        await moduleAppService.CeateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpPut("{id:guid}")]
    [Authorize(HealNetPermissions.Authorizations.Modules.Update)]
    public async Task UpdateAsync(Guid id, [FromBody] ModuleUpdateDto input, CancellationToken cancellationToken = default)
    {
        await moduleAppService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 模块列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    
    [HttpGet]
    [Authorize(HealNetPermissions.Authorizations.Modules.Default)]
    public async Task<PagedResultDto<ModuleListDto>> GetListAsync([FromQuery] ModuleInput input, CancellationToken cancellationToken = default)
    {
        return await moduleAppService.GetListAsync(input, cancellationToken);
    }

    /// <summary>
    ///  详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>模块详情</returns>
    [HttpGet("{id:guid}")]
    [Authorize(HealNetPermissions.Authorizations.Modules.Default)]
    public async Task<ModuleDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await moduleAppService.GetAsync(id, cancellationToken);
    }
}