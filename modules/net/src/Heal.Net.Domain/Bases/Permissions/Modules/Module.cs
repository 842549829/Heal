using Heal.Domain.Shared.Enums;

namespace Heal.Net.Domain.Bases.Permissions.Modules;

/// <summary>
/// 模块 
/// </summary>
public class Module
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="name">名称 </param>
    /// <param name="parentName">父级名称</param>
    /// <param name="displayName">显示名称</param>
    /// <param name="type">类型</param>
    /// <param name="path">路径</param>
    /// <param name="icon">图标</param>
    public Module(string name, string? parentName, string displayName, ModuleType type, string path, string? icon)
    {
        Name = name;
        ParentName = parentName;
        DisplayName = displayName;
        Type = type;
        Path = path;
        Icon = icon;
    }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// 父级名称
    /// </summary>
    public string? ParentName { get; private set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public string DisplayName { get; private set; }

    /// <summary>
    /// 模块类型
    /// </summary>
    public ModuleType Type { get; private set; }

    /// <summary>
    /// 前端地址
    /// </summary>
    public string Path { get; private set; }

    /// <summary>
    /// 前端图标
    /// </summary>
    public string? Icon { get; private set; }
}