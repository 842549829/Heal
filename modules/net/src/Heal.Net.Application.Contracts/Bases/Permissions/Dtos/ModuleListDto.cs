using Heal.Domain.Shared.Enums;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

/// <summary>
/// 模块列表
/// </summary>
public class ModuleListDto : EntityDto<Guid>
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public required string DislayName { get; init; }

    /// <summary>
    /// 标签[特殊标记;比如1标记是跳转第三方的]
    /// </summary>
    public required ModuleTag Tag { get; init; }
}