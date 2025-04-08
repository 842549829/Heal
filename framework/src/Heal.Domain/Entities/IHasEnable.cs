using Heal.Domain.Shared.Enums;

namespace Heal.Domain.Entities;

/// <summary>
/// 启用状态
/// </summary>
public interface IHasEnable
{
    /// <summary>
    /// 启用状态
    /// </summary>
    Enable Status { get; }
}