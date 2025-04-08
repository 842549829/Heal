namespace Heal.Domain.Entities;

/// <summary>
/// 扩展属性
/// </summary>
public interface IHasCode
{
    /// <summary>
    /// 编码
    /// </summary>
    string Code { get; }
}