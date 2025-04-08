namespace Heal.Domain.Entities;

/// <summary>
/// 带名称的实体
/// </summary>
public interface IHasName
{
    /// <summary>
    /// 名称
    /// </summary>
    string Name { get;  }
}