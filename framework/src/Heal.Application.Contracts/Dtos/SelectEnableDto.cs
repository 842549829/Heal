using Heal.Domain.Shared.Enums;

namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 启用状态选择
/// </summary>
public class SelectEnableDto : SelectDto, IHasEnableDto
{
    /// <summary>
    /// 启用状态
    /// </summary>
    public required Enable Status { get; init; }
}