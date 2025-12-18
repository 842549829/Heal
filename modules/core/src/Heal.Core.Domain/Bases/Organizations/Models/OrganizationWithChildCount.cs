namespace Heal.Core.Domain.Bases.Organizations.Models;

/// <summary>
/// 组织机构树节点
/// </summary>
public class OrganizationWithChildCount
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid  Id { get; set; }

    /// <summary>
    /// 数量
    /// </summary>
    public long Count { get; set; }
};