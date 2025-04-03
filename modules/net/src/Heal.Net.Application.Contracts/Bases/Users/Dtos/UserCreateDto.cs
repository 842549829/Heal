using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 创建用户
/// </summary>
public class UserCreateDto : IdentityUserCreateDto
{
    /// <summary>
    /// 组织id
    /// </summary>
    public Guid OrganizationId { get; set; }
}