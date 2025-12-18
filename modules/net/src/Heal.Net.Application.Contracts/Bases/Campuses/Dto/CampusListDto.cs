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
    public required string Name { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; set; }

    /// <summary>
    /// 迸发标记
    /// </summary>
    public required string ConcurrencyStamp { get; set; }
}