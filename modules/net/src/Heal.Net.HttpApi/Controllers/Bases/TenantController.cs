using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.TenantManagement;
using ITenantAppService = Heal.Net.Application.Contracts.Bases.Tenants.ITenantAppService;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 租户控制器
/// </summary>
/// <param name="tenantAppService">租户管理接口</param>
[Route("api/basics/tenants")]
[ApiController]
public class TenantController(ITenantAppService tenantAppService) : HealNetController
{
    /// <summary>
    /// 获取租户
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>租户</returns>
    [HttpGet]
    [Route("{id:guid}")]
    public virtual Task<TenantDto> GetAsync(Guid id)
    {
        return tenantAppService.GetAsync(id);
    }

    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>租户列表</returns>
    [HttpGet]
    public virtual Task<PagedResultDto<TenantDto>> GetListAsync([FromQuery]GetTenantsInput input)
    {
        return tenantAppService.GetListAsync(input);
    }

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns>租户实体</returns>
    [HttpPost]
    public virtual Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        ValidateModel();
        return tenantAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">租户信息</param>
    /// <returns>租户实体</returns>
    [HttpPut]
    [Route("{id:guid}")]
    public virtual Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        return tenantAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户Id</param>
    /// <returns>Task</returns>
    [HttpDelete]
    [Route("{id:guid}")]
    public virtual Task DeleteAsync(Guid id)
    {
        return tenantAppService.DeleteAsync(id);
    }
}