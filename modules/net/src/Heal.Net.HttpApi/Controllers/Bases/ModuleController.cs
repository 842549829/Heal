using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Microsoft.AspNetCore.Mvc;

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
    /// <returns>Task</returns>
    [HttpPost]
    public async Task<StatusCodeResult> CreateAsync([FromBody] ModuleCreateDto input)
    {
        await moduleAppService.CeateAsync(input);
        return Ok();
    }

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    [HttpPut("{id:guid}")]
    public async Task<StatusCodeResult> UpdateAsync(Guid id, [FromBody] ModuleUpdateDto input)
    {
        await moduleAppService.UpdateAsync(id, input);
        return Ok();
    }
}