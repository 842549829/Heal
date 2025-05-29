using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 模块类型
/// </summary>
public enum ModuleType
{
    /// <summary>
    /// 本地系统
    /// </summary>
    [Description("本地系统")]
    Local,

    /// <summary>
    /// 第三方系统
    /// </summary>
    [Description("第三方系统")]
    Other
}