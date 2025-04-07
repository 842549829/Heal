using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Users;

/// <summary>
/// 用户服务
/// </summary>
public interface IUserAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <returns>用户</returns>
    Task<IdentityUserDto> CreateAsync(UserCreateDto input);

    /// <summary>
    /// 更新用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input"></param>
    /// <returns>用户</returns>
    Task<IdentityUserDto> UpdateAsync(Guid id, UserUpdateDto input);

    /// <summary>
    /// 获取用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户</returns>
    Task<IdentityUserDto> GetAsync(Guid id);

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input);

    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// 获取用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <returns>用户角色</returns>
    Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);

    /// <summary>
    /// 获取可分配角色
    /// </summary>
    /// <returns>用户角色</returns>
    Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync();

    /// <summary>
    /// 更新用户角色
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>用户角色</returns>
    Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input);

    /// <summary>
    /// 根据用户名查找用户
    /// </summary>
    /// <param name="userName">用户名</param>
    /// <returns>用户</returns>
    Task<IdentityUserDto?> FindByUsernameAsync(string userName);

    /// <summary>
    /// 根据邮箱查找用户
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>用户</returns>
    Task<IdentityUserDto?> FindByEmailAsync(string email);

    /// <summary>
    /// 获取用户详情
    /// </summary>
    /// <param name="id">用户id</param>
    Task<IdentityUserDetailDto> GetAsyncDetail(Guid id);

    /// <summary>
    /// 更新用户头像
    /// </summary>
    /// <param name="id">用户id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    Task UpdateAvatarAsync(Guid id, UserAvatarUpdateDto input);

    /// <summary>
    /// 获取用户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>用户列表</returns>
    Task<IEnumerable<SearchUserOutputDto>> GetUsersAsync(SearchUserListInputDto input);

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <returns>角色列表</returns>
    Task<IEnumerable<RoleDto>> GetRoleAsync();
}