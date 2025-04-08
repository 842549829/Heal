namespace Heal.Domain.Entities;

/// <summary>
/// 带名称的实体
/// </summary>
public interface IHasNameExtension : IHasName
{
    /// <summary>
    /// 设置名称
    /// </summary>
    /// <param name="name">名称</param>
    public void SetName(string name);
}