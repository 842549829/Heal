using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 权限类型
/// </summary>
public enum PermissionType
{
    /// <summary>
    /// 模块
    /// </summary>
    [Description("模块")]
    Module = 1,

    /// <summary>
    /// 菜单
    /// </summary>
    [Description("菜单")]
    Menu = 2,

    /// <summary>
    /// 按钮
    /// </summary>
    [Description("按钮")]
    Button = 3
}