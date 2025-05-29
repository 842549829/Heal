using Heal.Domain.Shared.Enums;

namespace Heal.Domain.Shared.Models.Organizations;

/// <summary>
/// 组织关系扩展
/// </summary>
public static class OrganizationRelationshipExtension
{
    /// <summary>
    /// 获取指定类型的组织关系
    /// </summary>
    /// <param name="relationship">relationship</param>
    /// <param name="type">组织类型</param>
    /// <returns>组织关系集合</returns>
    public static List<OrganizationRelationship> GetRelationshipsByType(this OrganizationRelationship relationship, OrganizationType type)
    {
        var list = new List<OrganizationRelationship>();
        if (relationship.Type == type)
        {
            list.Add(relationship);
        }
        foreach (var item in relationship.Children)
        {
            list.AddRange(item.GetRelationshipsByType(type));
        }
        return list;
    }

    /// <summary>
    /// 获取指定类型的组织关系
    /// </summary>
    /// <param name="relationships">relationships</param>
    /// <param name="type">组织类型</param>
    /// <returns>组织关系集合</returns>
    public static List<OrganizationRelationship> GetRelationshipsByType(this List<OrganizationRelationship> relationships, OrganizationType type)
    {
        return relationships.SelectMany(x => x.GetRelationshipsByType(type)).ToList();
    }
}