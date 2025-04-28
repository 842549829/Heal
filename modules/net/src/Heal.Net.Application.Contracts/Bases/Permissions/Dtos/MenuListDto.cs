using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 菜单列表
/// </summary>
public class MenuListDto : EntityDto<Guid>
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 权限组
    /// </summary>
    public required string GroupName { get; init; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public required string DislayName { get; init; }
}