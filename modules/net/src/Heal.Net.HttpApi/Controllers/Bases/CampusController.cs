using Heal.Net.Application.Contracts.Bases.Campuses;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    /// <returns>院区</returns>
    [HttpPost]
    [AllowAnonymous]
    public Task<CampusDto> CreateAsync([FromBody] CampusCreateDto input)
    {
        return campusAppService.CreateAsync(input);
    }
}