using Heal.Net.Application.Contracts.Bases.Campuses;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Heal.Net.Application.Contracts.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 院区信息模块
/// </summary>
/// <param name="campusAppService">院区应用服务接口</param>
[Route("api/net/basics/campuses")]
[ApiController]
public class CampusController(ICampusAppService campusAppService) : HealNetController
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    [HttpPost]
    [Authorize(HealNetPermissions.Campuses.Create)]
    public Task<CampusDto> CreateAsync([FromBody] CampusCreateDto input, CancellationToken cancellationToken)
    {
        return campusAppService.CreateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新院区
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="input">院区更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    [HttpPut("{id:guid}")]
    [Authorize(HealNetPermissions.Campuses.Update)]
    public Task<CampusDto> UpdateAsync(Guid id, [FromBody] CampusUpdateDto input,
        CancellationToken cancellationToken = default)
    {
        return campusAppService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input">输入</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区列表</returns>
    [HttpGet]
    [Authorize(HealNetPermissions.Campuses.Default)]
    public Task<PagedResultDto<CampusListDto>> GetListAsync([FromQuery] CampusInput input,
        CancellationToken cancellationToken = default)
    {
        return campusAppService.GetListAsync(input, cancellationToken);
    }
}