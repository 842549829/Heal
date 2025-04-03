using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 用户头像更新
/// </summary>
public class UserAvatarUpdateDto : ExtensibleObject, IHasConcurrencyStamp
{
    /// <summary>
    /// 版本
    /// </summary>
    public required string ConcurrencyStamp { get; set; }
}