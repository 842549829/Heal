using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 权限组定义
/// </summary>
public class PermissionGroupDefinitionDto : ExtensibleEntityDto<Guid>
{
    /// <summary>
    /// 权限组名称
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 权限组显示名称
    /// </summary>
    public required string DisplayName { get; set; }
}