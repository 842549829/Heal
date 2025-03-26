using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 刷新token
/// </summary>
public class RefreshTokenInputDto : EntityDto
{
    /// <summary>
    /// 刷新token
    /// </summary>
    [Required(ErrorMessage = "刷新token不能为空")]
    public string RefreshToken { get; set; } = null!;
}