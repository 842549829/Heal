using Heal.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Departments.Dto;

/// <summary>
/// 科室列表
/// </summary>
public class DepartmentListDto : EntityDto<Guid>,
    IHasCodeDto,
    IHasNameDto,
    IHasOrganizationDto,
    IHasSortDto,
    IMayHaveDescribeDto,
    IHasConcurrencyStampDto
{
    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; init; }

    /// <summary>
    /// 组织名称
    /// </summary>
    public required string OrganizationName { get; init; }

    /// <summary>
    /// 院区Code
    /// </summary>
    public required string CampusCode { get; init; }

    /// <summary>
    /// 院区名称
    /// </summary>
    public required string CampusName { get; init; }

    /// <summary>
    /// 科室负责人
    /// </summary>
    public string? HeadOfDepartment { get; init; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfDepartmentPhone { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; init; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; init; }

    /// <summary>
    /// 迸发标记
    /// </summary>
    public required string ConcurrencyStamp { get; init; }
}