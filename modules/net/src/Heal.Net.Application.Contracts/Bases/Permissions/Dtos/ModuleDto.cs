using Heal.Domain.Shared.Enums;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 模块
/// </summary>
public class ModuleDto
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 父级名称
    /// </summary>
    public string? ParentName { get; init; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public required string DisplayName { get; init; }

    /// <summary>
    /// 模块类型
    /// </summary>
    public required ModuleType Type { get; init; }

    /// <summary>
    /// 前端地址
    /// </summary>
    public required string Path { get; init; }

    /// <summary>
    /// 前端图标
    /// </summary>
    public string? Icon { get; init; }
}