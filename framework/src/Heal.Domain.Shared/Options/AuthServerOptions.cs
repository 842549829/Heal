namespace Heal.Domain.Shared.Options;

/// <summary>
/// 授权客户端
/// </summary>
public class AuthServerOptions
{
    /// <summary>
    /// 客户端Id
    /// </summary>
    public string ClientId { get; set; } = null!;

    /// <summary>
    /// 客户端key
    /// </summary>
    public string ClientSecret { get; set; } = null!;

    /// <summary>
    /// 范围
    /// </summary>
    public string Scope { get; set; } = null!;

    /// <summary>
    /// GrantType类型
    /// </summary>
    public string GrantType { get; set; } = null!;

    /// <summary>
    /// 地址
    /// </summary>
    public string Authority { get; set; } = null!;

    /// <summary>
    /// 是否需要https
    /// </summary>
    public bool RequireHttpsMetadata { get; set; }
}