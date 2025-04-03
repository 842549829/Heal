using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 用户搜索结果
/// </summary>
public class SearchUserOutputDto : EntityDto<Guid>
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string? UserName { get; set; } 

    /// <summary>
    /// 姓名
    /// </summary>
    public string? FullName { get; set; } 
}