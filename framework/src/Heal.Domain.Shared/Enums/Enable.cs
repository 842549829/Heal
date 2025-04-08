using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 启用状态
/// </summary>
public enum Enable
{
    /// <summary>
    /// 启用
    /// </summary>
    [Description("启用")]
    Enabled = 1,

    /// <summary>
    /// 禁用
    /// </summary>
    [Description("禁用")]
    Disabled = 0
}