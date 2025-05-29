using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 组织类型
/// </summary>
public enum OrganizationType
{
    /// <summary>
    /// 机构
    /// </summary>
    [Description("机构")]
    Organization = 1,

    /// <summary>
    /// 院区
    /// </summary>
    [Description("院区")]
    Campus = 2,

    /// <summary>
    /// 科室
    /// </summary>
    Department = 3
}