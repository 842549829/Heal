namespace Heal.Domain.Shared.Constants;

/// <summary>
/// Token请求授权类型常量
/// </summary>
public static class TokenRequestGrantTypeConsts
{
    /// <summary>
    /// 授权类型(医护人员)
    /// </summary>
    public const string HealNetPassword = "heal_net_password";

    /// <summary>
    /// 授权类型(患者)
    /// </summary>
    public const string HealMovePassword = "heal_move_password";
}