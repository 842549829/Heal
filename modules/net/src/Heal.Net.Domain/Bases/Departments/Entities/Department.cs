using Heal.Domain.Entities;

namespace Heal.Net.Domain.Bases.Departments.Entities;

/// <summary>
/// 科室
/// </summary>
public class Department(Guid id, string name) : FullHealthcareAuditedAggregateRoot<Guid>(id, name)
{
    /// <summary>
    /// 所在院区
    /// </summary>
    public Guid? CampusId { get; private set; }

    /// <summary>
    /// 设置所在院区
    /// </summary>
    /// <param name="campusId">所在院区</param>
    public void SetCampus(Guid campusId)
    {
        CampusId = campusId;
    }

    /// <summary>
    /// 科室简称
    /// </summary>
    public string? ShortName { get; set; }

    /// <summary>
    /// 科室类型
    /// </summary>
    public Guid DepartmentTypeId { get; set; }

    /// <summary>
    /// 科室类型
    /// </summary>
    public virtual DepartmentType DepartmentType { get; set; } = null!;

    /// <summary>
    /// 所在院区
    /// </summary>
    public string? Campuses { get; set; }

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
    public string? Address { get; set; } = null!;

    /// <summary>
    /// 床位数/接待能力(该科室可容纳的最大病人数或接诊量)
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
    /// 科室负责人
    /// </summary>
    public string? HeadOfDepartment { get; set; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfDepartmentPhone { get; set; }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfDepartmentEmail { get; set; }

    /// <summary>
    /// 科室网站
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
}