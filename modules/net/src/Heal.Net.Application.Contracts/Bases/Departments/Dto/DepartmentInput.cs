using Heal.Application.Contracts.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Departments.Dto;

public class DepartmentInput : FilterInput
{
    /// <summary>
    /// 组织Code
    /// </summary>
    public string? OrganizationCode { get; init; }
    
    /// <summary>
    /// 院区Code
    /// </summary>
    public string? CampusCode { get; init; }
}