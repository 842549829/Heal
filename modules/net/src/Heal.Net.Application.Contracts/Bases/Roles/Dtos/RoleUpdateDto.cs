using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Contracts.Bases.Roles.Dtos;

/// <summary>
/// 角色信息
/// </summary>
public class RoleUpdateDto : IdentityRoleUpdateDto
{
    /// <summary>
    /// 权限信息
    /// </summary>
    public required List<UpdatePermissionDto> Permissions { get; set; }
}