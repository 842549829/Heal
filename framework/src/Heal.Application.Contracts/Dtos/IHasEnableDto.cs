using Heal.Domain.Shared.Enums;

namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 启用状态
/// </summary>
public interface IHasEnableDto
{
    /// <summary>
    /// 启用状态
    /// </summary>
    Enable Status { get; }
}