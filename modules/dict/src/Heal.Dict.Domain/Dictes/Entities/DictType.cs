using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Dictes.Entities;

/// <summary>
/// 字典类型
/// </summary>
public class DictType : HealthcareAuditedAggregateRoot<Guid>
{
    /// <summary>
    /// 基础聚合根
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    public DictType(Guid id, string name) : base(id, name)
    {
    }

    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    public DictType(Guid id, string name, string code) : base(id, name, code)
    {
    }

    /// <summary>
    /// 父级id
    /// </summary>
    public Guid? ParentId { get; private set; }

    /// <summary>
    /// 设置父级id
    /// </summary>
    /// <param name="parentId">父级id</param>
    public void SetParentId(Guid? parentId)
    {
        ParentId = parentId;
    }

    /// <summary>
    /// 字典项集合
    /// </summary>
    public ICollection<DictItem>? Items { get; set; }
}