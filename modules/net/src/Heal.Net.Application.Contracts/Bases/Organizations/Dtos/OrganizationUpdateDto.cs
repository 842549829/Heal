using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;

namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 组织更新
/// </summary>
public class OrganizationUpdateDto : ExtensibleObject, IHasConcurrencyStamp
{
    /// <summary>
    /// 版本
    /// </summary>
    public required string ConcurrencyStamp { get; set; }

    /// <summary>
    /// 组织名称
    /// </summary>
    public required string DisplayName { get; set; }
}