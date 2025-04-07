using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 身份类型
/// </summary>
[Flags]
public enum IdentityType
{
    /// <summary>
    /// 医护人员
    /// </summary>
    [Description("医护人员")]
    Doctor = 1,

    /// <summary>
    /// 患者
    /// </summary>
    [Description("患者")]
    Patient = 2
}