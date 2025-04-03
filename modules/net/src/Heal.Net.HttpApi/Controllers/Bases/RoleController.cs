using Heal.Net.Application.Contracts.Bases.Roles;
using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 角色管理
/// </summary>
/// <param name="roleAppService">角色服务</param>
[Route("api/net/basics/roles")]
[ApiController]
public class RoleController(IRoleAppService roleAppService) : HealNetController
{
    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>角色列表</returns>
    [HttpGet]
    //[Authorize("AbpIdentity.Users")]
    public Task<PagedResultDto<IdentityRoleDto>> GetListAsync([FromQuery] GetIdentityRolesInput input)
    {
        return roleAppService.GetListAsync(input);
    }

    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>角色</returns>
    [HttpGet]
    [Route("{id:guid}")]
    public Task<RoleDto> GetAsync(Guid id)
    {
        return roleAppService.GetAsync(id);
    }

    /// <summary>
    /// 获取角色权限
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>权限</returns>
    [HttpGet("permissions/{id:guid}")]
    public Task<List<string>> GetPermissionListAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return roleAppService.GetPermissionListAsync(id, cancellationToken);
    }

    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>所有角色</returns>
    [HttpGet("all")]
    public Task<List<string>> GetAllAsync()
    {
        return roleAppService.GetAllAsync();
    }

    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="input">角色创建</param>
    /// <returns>角色</returns>
    [HttpPost]
    public Task<IdentityRoleDto> CreateAsync(RoleCreateDto input)
    {
        return roleAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <param name="input">角色更新</param>
    /// <returns>角色</returns>
    [HttpPut]
    [Route("{id:guid}")]
    public Task<IdentityRoleDto> UpdateAsync(Guid id, RoleUpdateDto input)
    {
        return roleAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <returns>Task</returns>
    [HttpDelete]
    [Route("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        return roleAppService.DeleteAsync(id);
    }
}