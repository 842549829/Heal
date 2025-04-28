using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 菜单管理
/// </summary>
[ApiController]
[Route("api/net/basics/menus")]
public class MenuController(IMenuAppService menuAppService) : HealNetController
{
    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpPost]
    public async Task CreateAsync([FromBody] MenuCreateDto input, CancellationToken cancellationToken = default)
    {
        await menuAppService.CeateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpPut("{id:guid}")]
    public async Task UpdateAsync(Guid id, [FromBody] MenuUpdateDto input, CancellationToken cancellationToken = default)
    {
        await menuAppService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 菜单列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    [HttpGet]
    public async Task<PagedResultDto<MenuListDto>> GetListAsync([FromQuery] MenuInput input, CancellationToken cancellationToken = default)
    {
        return await menuAppService.GetListAsync(input, cancellationToken);
    }

    /// <summary>
    ///  详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>菜单详情</returns>
    [HttpGet("{id:guid}")]
    public async Task<MenuDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await menuAppService.GetAsync(id, cancellationToken);
    }
}