using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 模块标签
/// </summary>
[Flags]
public enum ModuleTag
{
    /// <summary>
    /// 正常
    /// </summary>
    [Description("正常")]
    Normal = 1,

    /// <summary>
    /// 跳转第三方
    /// </summary>
    [Description("跳转第三方")]
    ThirdParty = 2,

    /// <summary>
    /// 系统(不允许删除) 
    /// </summary>
    [Description("系统")]
    System = 4,

    /// <summary>
    /// 正常系统
    /// </summary>
    [Description("正常系统")]
    NormalSystem = Normal | System,
}