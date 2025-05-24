using Heal.Application.Contracts.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Departments.Dto;

/// <summary>
/// 科室创建
/// </summary>
public class DepartmentCreateDto : DepartmentCreateOrUpdateDto, IHasOrganizationDto
{
    /// <summary>
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; init; }
    
    /// <summary>
    /// 所在院区
    /// </summary>
    public required Guid CampusId { get; init; }
}