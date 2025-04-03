using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Roles;

/// <summary>
/// 角色服务
/// </summary>
public interface IRoleAppService : IApplicationService
{
    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="input">角色创建</param>
    /// <returns>角色</returns>
    Task<IdentityRoleDto> CreateAsync(RoleCreateDto input);

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <param name="input">角色更新</param>
    /// <returns>角色</returns>
    Task<IdentityRoleDto> UpdateAsync(Guid id, RoleUpdateDto input);

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>角色列表</returns>
    Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input);

    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>角色</returns>
    Task<RoleDto> GetAsync(Guid id);

    /// <summary>
    /// 获取角色权限
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>权限</returns>
    Task<List<string>> GetPermissionListAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>所有角色</returns>
    Task<List<string>> GetAllAsync();
}