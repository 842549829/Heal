using Heal.Domain.Shared.Enums;

namespace Heal.Domain.Shared.Models.Organizations;

/// <summary>
/// 组织关系
/// </summary>
public class OrganizationRelationship
{
    /// <summary>
    /// 组织ID
    /// </summary>
    public required Guid Id { get; init; }

    /// <summary>
    /// 组织编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 组织名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 组织类型
    /// </summary>
    public required OrganizationType Type { get; init; }

    /// <summary>
    /// 子项
    /// </summary>
    public required List<OrganizationRelationship> Children { get; init; }
}