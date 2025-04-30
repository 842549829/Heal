namespace Heal.Core.Domain.Bases.Organizations.Models;

/// <summary>
/// 组织机构树节点
/// </summary>
/// <param name="Id">Id</param>
/// <param name="Count">数量</param>
public record OrganizationWithChildCount(Guid Id, int Count);