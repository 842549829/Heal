namespace Heal.Domain.Entities;

/// <summary>
/// 带父级和子集的审计聚合根
/// </summary>
/// <typeparam name="TKey">key</typeparam>
/// <param name="id">id</param>
/// <param name="name">name</param>
/// <param name="code">code</param>
public abstract class FullParentHealthcareAuditedAggregateRoot<TKey>(TKey id, string name, string code) : FullHealthcareAuditedAggregateRoot<TKey>(id, name, code), IMayHaveParentIdExtension
{
    /// <summary>
    /// 父级id
    /// </summary>
    public Guid? ParentId { get; private set; }

    /// <summary>
    /// 设置父级
    /// </summary>
    /// <param name="parentId">父级Id</param>
    public void SetParent(Guid? parentId)
    {
        ParentId = parentId;
    }
}