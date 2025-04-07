using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 数据权限
/// </summary>
public enum DataPermission
{
    /// <summary>
    /// 无
    /// </summary>
    [Description("无")]
    None = 0,

    /// <summary>
    /// 全部数据权限
    /// </summary>
    [Description("全部数据权限")]
    All = 1,

    /// <summary>
    /// 本门组织
    /// </summary>
    [Description("本门组织")]
    Cur = 2,

    /// <summary>
    /// 下级组织数据权限
    /// </summary>
    [Description("下级组织数据权限")]
    Sub = 3,

    /// <summary>
    /// 本组织及下级组织数据权限
    /// </summary>
    [Description("本组织及下级组织数据权限")]
    CurAndSub = 4,

    /// <summary>
    /// 自定义
    /// </summary>
    [Description("自定义")]
    Custom = 5
}