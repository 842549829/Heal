using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;


/// <summary>
/// 登录结果
/// </summary>
public class LoginResultDto : EntityDto
{
    /// <summary>
    /// token
    /// </summary>
    public required string AccessToken { get; set; }

    /// <summary>
    /// 刷新token
    /// </summary>
    public required string RefreshToken { get; set; }

    /// <summary>
    /// token过期时间
    /// </summary>
    public required int ExpiresIn { get; set; }

    /// <summary>
    /// token类型
    /// </summary>
    public required string TokenType { get; set; }
}