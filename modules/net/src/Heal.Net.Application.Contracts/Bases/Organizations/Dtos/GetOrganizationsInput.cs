using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 获取组织列表
/// </summary>
public class GetOrganizationsInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 排序字段
    /// </summary>
    public override string? Sorting { get; set; } = nameof(OrganizationDto.Code);

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 过滤条件
    /// </summary>
    public string? Filter { get; set; }
}