using Volo.Abp.ObjectExtending;

namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 组织创建
/// </summary>
public class OrganizationCreateDto : ExtensibleObject
{
    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 组织名称
    /// </summary>
    public required string DisplayName { get; set; }
}