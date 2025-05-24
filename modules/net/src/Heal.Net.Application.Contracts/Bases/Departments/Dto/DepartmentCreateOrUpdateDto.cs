using Heal.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Departments.Dto;

/// <summary>
/// 科室创建或更新Dto
/// </summary>
public class DepartmentCreateOrUpdateDto : EntityDto, IHasNameDto ,IHasSortDto, IMayHaveDescribeDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; init;}

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; init; }
    
    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; init;}

    /// <summary>
    /// 科室简称
    /// </summary>
    public string? ShortName { get; init; }

    /// <summary>
    /// 科室类型
    /// </summary>
    public Guid DepartmentTypeId { get; init; }

    /// <summary>
    /// 所在院区名称
    /// </summary>
    public string? Campuses { get; init; }

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
    /// 床位数/接待能力(该科室可容纳的最大病人数或接诊量)
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
    /// 科室负责人
    /// </summary>
    public string? HeadOfDepartment { get; init; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfDepartmentPhone { get; init; }

    /// <summary>
    /// 负责人邮箱
    /// </summary>
    public string? HeadOfDepartmentEmail { get; init; }

    /// <summary>
    /// 科室网站
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
}