using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 用户详情信息
/// </summary>
public class IdentityUserDetailDto : IdentityUserDto
{
    /// <summary>
    /// 角色名称
    /// </summary>
    public required string[] RoleNames { get; set; }
}