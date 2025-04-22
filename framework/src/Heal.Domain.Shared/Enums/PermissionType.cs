using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 权限类型
/// </summary>
public enum PermissionType
{
    /// <summary>
    /// 系统
    /// </summary>
    [Description("系统")]
    System,

    /// <summary>
    /// 模块
    /// </summary>
    [Description("模块")]
    Module,

    /// <summary>
    /// 菜单
    /// </summary>
    [Description("菜单")]
    Menu,

    /// <summary>
    /// 按钮
    /// </summary>
    [Description("按钮")]
    Button
}