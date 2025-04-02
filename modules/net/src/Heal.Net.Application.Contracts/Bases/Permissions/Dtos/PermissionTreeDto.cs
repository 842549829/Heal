using Heal.Domain.Shared.Enums;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 权限树
/// </summary>
public class PermissionTreeDto
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 父级权限名称
    /// </summary>
    public string? ParentName { get; set; }

    /// <summary>
    /// 权限显示名称
    /// </summary>
    public string? DisplayName { get; set; }

    /// <summary>
    /// 权限路径
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// 图标
    /// </summary>
    public string? Iocn { get; set; }

    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType? Type { get; set; }

    /// <summary>
    /// 子权限
    /// </summary>
    public List<PermissionTreeDto>? ChildPermissions { get; set; }
}