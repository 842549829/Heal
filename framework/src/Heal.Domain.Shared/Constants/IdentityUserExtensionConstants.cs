namespace Heal.Domain.Shared.Constants;

/// <summary>
/// IdentityUser扩展常量
/// </summary>
public static class IdentityUserExtensionConstants
{
    /// <summary>
    /// OpenId
    /// </summary>
    public const string OpenId = "OpenId";

    /// <summary>
    /// 头像
    /// </summary>
    public const string Avatar = "Avatar";

    /// <summary>
    /// 身份标识
    /// </summary>
    public const string Identity = "Identity";

    /// <summary>
    /// MaxOpenIdLength
    /// </summary>
    public static int MaxOpenIdLength { get; set; } = 256;

    /// <summary>
    /// MaxAvatarLength
    /// </summary>
    public static int MaxAvatarLength { get; set; } = 512;
}