using Heal.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses.Dto;

/// <summary>
/// 获取校区列表
/// </summary>
public class CampusListDto : EntityDto<Guid>,
    IHasCodeDto,
    IHasNameDto,
    IHasOrganizationDto,
    IHasSortDto,
    IMayHaveDescribeDto,
    IHasConcurrencyStampDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; init; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; init; }

    /// <summary>
    /// 迸发标记
    /// </summary>
    public required string ConcurrencyStamp { get; init; }
}