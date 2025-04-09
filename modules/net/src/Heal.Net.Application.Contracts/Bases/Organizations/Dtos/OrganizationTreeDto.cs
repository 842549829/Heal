namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 组织树形结构
/// </summary>
public class OrganizationTreeDto : OrganizationDto
{
    /// <summary>
    /// 是否有子节点
    /// </summary>
    public bool? HasChildren { get; set; }

    /// <summary>
    /// 子节点
    /// </summary>
    public List<OrganizationTreeDto>? Children { get; set; }
}