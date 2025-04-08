namespace Heal.Domain.Entities;

/// <summary>
/// 用户基础信息扩展
/// </summary>
public interface IHasUserBaseInfoExtension : IHasUserBaseInfo
{
    /// <summary>
    /// 设置生日
    /// </summary>
    /// <param name="birthday">生日</param>
    public void SetBirthday(DateTime? birthday);

    /// <summary>
    /// 设置邮箱
    /// </summary>
    /// <param name="email">邮箱</param>
    public void SetEmail(string? email);
}