using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Application.Contracts.Bases.Users;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 用户管理
/// </summary>
/// <param name="userAppService">用户服务</param>
[Route("api/net/basics/users")]
[ApiController]
public class UserController(IUserAppService userAppService) : HealNetController
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <returns>用户</returns>
    [HttpPost]
    public Task<IdentityUserDto> CreateAsync([FromBody] UserCreateDto input)
    {
        return userAppService.CreateAsync(input);
    }

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input"></param>
    /// <returns>用户</returns>
    [HttpPut("{id:guid}")]
    public Task<IdentityUserDto> UpdateAsync(Guid id, UserUpdateDto input)
    {
        return userAppService.UpdateAsync(id, input);
    }

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户</returns>
    [HttpGet]
    [Route("{id:guid}")]
    [Authorize]
    public Task<IdentityUserDto> GetAsync(Guid id)
    {
        return userAppService.GetAsync(id);
    }

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="id">用户id</param>
    [HttpGet]
    [Route("{id:guid}/detail")]
    [Authorize]
    public Task<IdentityUserDetailDto> GetAsyncDetail(Guid id)
    {
        return userAppService.GetAsyncDetail(id);
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    [HttpGet]
    public Task<PagedResultDto<IdentityUserDto>> GetListAsync([FromQuery] GetIdentityUsersInput input)
    {
        return userAppService.GetListAsync(input);
    }

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>Task</returns>
    [HttpDelete]
    [Route("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        return userAppService.DeleteAsync(id);
    }

    /// <summary>
    /// 获取用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户角色</returns>
    [HttpGet]
    [Route("{id:guid}/roles")]
    public Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
    {
        return userAppService.GetRolesAsync(id);
    }

    /// <summary>
    /// 获取可分配角色
    /// </summary>
    /// <returns>用户角色</returns>
    [HttpGet]
    [Route("assignable-roles")]
    public Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
    {
        return userAppService.GetAssignableRolesAsync();
    }

    /// <summary>
    /// 更新用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>用户角色</returns>
    [HttpPut]
    [Route("{id:guid}/roles")]
    public Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
    {
        return userAppService.UpdateRolesAsync(id, input);
    }

    /// <summary>
    /// 根据用户名查找用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns>用户</returns>
    [HttpGet]
    [Route("by-username/{userName}")]
    public Task<IdentityUserDto?> FindByUsernameAsync(string userName)
    {
        return userAppService.FindByUsernameAsync(userName);
    }

    /// <summary>
    /// 根据邮箱查找用户
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>用户</returns>
    [HttpGet]
    [Route("by-email/{email}")]
    public Task<IdentityUserDto?> FindByEmailAsync(string email)
    {
        return userAppService.FindByEmailAsync(email);
    }

    /// <summary>
    /// 更新用户头像
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    [HttpPut]
    [Route("{id:guid}/avatar")]
    public Task UpdateAvatarAsync(Guid id, [FromBody] UserAvatarUpdateDto input)
    {
        return userAppService.UpdateAvatarAsync(id, input);
    }

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    [HttpGet("user-select")]
    public Task<IEnumerable<SearchUserOutputDto>> GetUsersAsync([FromQuery] SearchUserListInputDto input)
    {
        return userAppService.GetUsersAsync(input);
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <returns>角色列表</returns>
    [HttpGet("role-select")]
    public Task<IEnumerable<RoleDto>> GetRoleAsync()
    {
        return userAppService.GetRoleAsync();
    }
}