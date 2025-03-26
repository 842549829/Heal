﻿using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 登录输入
/// </summary>
public class LoginInputDto : EntityDto
{
    /// <summary>
    /// 帐号
    /// </summary>
    [Required(ErrorMessage = "帐号不能为空")]
    [MaxLength(32, ErrorMessage = "帐号长度最长为32位字符")]
    public string UserName { get; set; } = null!;

    /// <summary>
    /// 登录凭证
    /// </summary>
    [Required(ErrorMessage = "验证密码不能为空")]
    [MaxLength(64, ErrorMessage = "帐号长度最长为64位字符")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; set; }

    ///// <summary>
    ///// 验证码
    ///// </summary>
    //public string? Captcha { get; set; }
}