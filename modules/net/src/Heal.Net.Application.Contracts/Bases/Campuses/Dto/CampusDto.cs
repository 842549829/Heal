using Heal.Application.Contracts.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses.Dto;

/// <summary>
/// 院区信息
/// </summary>
public class CampusDto : AuditedEntityExtensionDto<Guid>, 
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
    /// 组织Code
    /// </summary>
    public required string OrganizationCode { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    public string? ShortName { get; set; }

    /// <summary>
    /// 所在大楼
    /// </summary>
    public string? Building { get; set; }

    /// <summary>
    /// 所在楼层
    /// </summary>
    public string? Floor { get; set; }

    /// <summary>
    /// 房间号
    /// </summary>
    public string? RoomNumber { get; set; }

    /// <summary>
    /// 所在详细地址
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// 床位数/接待能力(该院区可容纳的最大病人数或接诊量)
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 院区负责人
    /// </summary>
    public string? HeadOfCampus { get; set; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfCampusPhone { get; set; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfCampusEmail { get; set; }

    /// <summary>
    /// 院区网站
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// 提供的服务
    /// </summary>
    public string? ServicesOffered { get; set; }

    /// <summary>
    /// 紧急联系人
    /// </summary>
    public string? EmergencyContact { get; set; }

    /// <summary>
    /// 紧急联系电话
    /// </summary>
    public string? EmergencyPhone { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; set; }
    
    /// <summary>
    /// 迸发标记
    /// </summary>
    public required string ConcurrencyStamp { get; set; }
}