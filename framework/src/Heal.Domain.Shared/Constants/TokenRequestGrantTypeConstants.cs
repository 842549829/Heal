namespace Heal.Domain.Shared.Constants;

/// <summary>
/// Token请求授权类型常量
/// </summary>
public static class TokenRequestGrantTypeConstants
{
    /// <summary>
    /// 授权类型(Net)
    /// </summary>
    public const string HealNetPassword = "heal_net_password";

    /// <summary>
    /// 授权类型(患者)
    /// </summary>
    public const string HealPatPassword = "heal_pat_password";

    /// <summary>
    /// 授权类型(医生)
    /// </summary>
    public const string HealDocPassword = "heal_doc_password";
}