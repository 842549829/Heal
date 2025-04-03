namespace Heal.Net.Application.Contracts.Bases.Users.Dtos;

/// <summary>
/// 用户列表查询
/// </summary>
public class SearchUserListInputDto
{
    /// <summary>
    /// 排序
    /// </summary>
    public string? Sorting { get; set; }

    /// <summary>
    /// 过滤
    /// </summary>
    public string? Filter { get; set; }

    /// <summary>
    /// 最大结果数
    /// </summary>
    public int MaxResultCount { get; set; } = 10;

    /// <summary>
    /// 用户Id
    /// </summary>
    public IEnumerable<Guid> UserIds { get; set; } = new List<Guid>();
}