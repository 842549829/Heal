using Volo.Abp.Identity;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 用户更新
/// </summary>
public class UserUpdateDto : IdentityUserUpdateDto
{
    /// <summary>
    /// 组织id
    /// </summary>
    public Guid OrganizationId { get; set; }
}