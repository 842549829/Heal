using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 创建用户
/// </summary>
public class CreateInputDto : EntityDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [Required(ErrorMessage = "名称不能为空")]
    public required string Name { get; set; }
}