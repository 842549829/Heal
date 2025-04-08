namespace Heal.Domain.Entities;

/// <summary>
/// 可修描述信息
/// </summary>
public interface IMayHaveDescribeExtension: IMayHaveDescribe
{
    /// <summary>
    /// 设置描述信息
    /// </summary>
    /// <param name="describe">描述信息</param>
    public void SetDescribe(string? describe);
}