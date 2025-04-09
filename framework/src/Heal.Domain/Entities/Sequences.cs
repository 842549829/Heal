using Volo.Abp.Domain.Entities;

namespace Heal.Domain.Entities;

/// <summary>
/// 序列
/// </summary>
public class Sequences : Entity<string>
{
    /// <summary>
    /// 值
    /// </summary>
    public string Value { get;  set; } = null!;
}