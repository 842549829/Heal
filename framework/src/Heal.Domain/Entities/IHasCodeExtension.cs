namespace Heal.Domain.Entities;

/// <summary>
/// 扩展属性
/// </summary>
public interface IHasCodeExtension : IHasCode
{
    /// <summary>
    /// 设置编码
    /// </summary>
    /// <param name="code">编码</param>
    public void SetCode(string code);
}