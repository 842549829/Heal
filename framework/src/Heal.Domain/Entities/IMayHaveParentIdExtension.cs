namespace Heal.Domain.Entities;

/// <summary>
/// 聚合根扩展
/// </summary>
public interface IMayHaveParentIdExtension : IMayHaveParentId
{
    /// <summary>
    /// 设置父级
    /// </summary>
    /// <param name="parentId">父级Id</param>
    public void SetParent(Guid? parentId);
}