using Heal.Domain.Shared.Enums;

namespace Heal.Domain.Entities;

/// <summary>
/// 启用状态
/// </summary>
public interface IHasEnableExtension : IHasEnable
{
    /// <summary>
    /// 设置启用状态
    /// </summary>
    /// <param name="status">状态</param>
    void SetStatus(Enable status);
}