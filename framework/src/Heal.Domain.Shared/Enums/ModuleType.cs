using System.ComponentModel;

namespace Heal.Domain.Shared.Enums;

/// <summary>
/// 模块类型
/// </summary>
public enum ModuleType
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
    Module
}