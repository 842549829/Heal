namespace Heal.Domain.Entities;

/// <summary>
/// 用户基础信息扩展
/// </summary>
public interface IHasUserBaseInfo : IMayHaveAddressExtension, IMayHaveAgeExtension, IHasIdCardExtension
{
    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// 性别
    /// </summary>
    public string Gender { get; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime? Birthday { get; }

    /// <summary>
    /// 电话号码
    /// </summary>
    public string Phone { get; }

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; }
}