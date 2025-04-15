using Heal.Application.Contracts.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses.Dto;

/// <summary>
/// 院区信息
/// </summary>
public class CampusDto : AuditedEntityExtensionDto<Guid>, IHasCodeDto, IHasNameDto, IHasOrganizationDto, IHasSortDto, IMayHaveDescribeDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; init; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; init; }

    /// <summary>
    /// 简称
    /// </summary>
    public string? ShortName { get; init; }

    /// <summary>
    /// 所在大楼
    /// </summary>
    public string? Building { get; init; }

    /// <summary>
    /// 所在楼层
    /// </summary>
    public string? Floor { get; init; }

    /// <summary>
    /// 房间号
    /// </summary>
    public string? RoomNumber { get; init; }

    /// <summary>
    /// 所在详细地址
    /// </summary>
    public string? Address { get; init; }

    /// <summary>
    /// 床位数/接待能力(该院区可容纳的最大病人数或接诊量)
    /// </summary>
    public int Capacity { get; init; }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Phone { get; init; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; init; }

    /// <summary>
    /// 院区负责人
    /// </summary>
    public string? HeadOfCampus { get; init; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfCampusPhone { get; init; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfCampusEmail { get; init; }

    /// <summary>
    /// 院区网站
    /// </summary>
    public string? Website { get; init; }

    /// <summary>
    /// 提供的服务
    /// </summary>
    public string? ServicesOffered { get; init; }

    /// <summary>
    /// 紧急联系人
    /// </summary>
    public string? EmergencyContact { get; init; }

    /// <summary>
    /// 紧急联系电话
    /// </summary>
    public string? EmergencyPhone { get; init; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }
}