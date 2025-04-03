using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Contracts.Bases.Roles.Dtos;

/// <summary>
/// 角色创建
/// </summary>
public class RoleCreateDto : IdentityRoleCreateDto
{
    /// <summary>
    /// 权限
    /// </summary>
    public required List<UpdatePermissionDto> Permissions { get; set; }
}