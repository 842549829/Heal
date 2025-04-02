using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 权限定义Dto
/// </summary>
public class PermissionDefinitionDto : ExtensibleEntityDto<Guid>
{
    /// <summary>
    /// 权限组名称
    /// </summary>
    public required string GroupName { get; set; }

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
    public required string DisplayName { get; set; }

    /// <summary>
    /// 是否启用
    /// </summary>
    public required bool IsEnabled { get; set; }

    /// <summary>
    /// 多租户
    /// </summary>
    public required MultiTenancySides MultiTenancySide { get; set; }

    /// <summary>
    /// 权限提供者
    /// </summary>
    public string? Providers { get; set; }

    /// <summary>
    /// 权限状态检查
    /// </summary>
    public string? StateCheckers { get; set; }
}