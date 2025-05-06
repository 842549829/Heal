using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Dictes.Entities;

/// <summary>
/// 字典项
/// </summary>
public class DictItem : HealthcareAuditedAggregateRoot<Guid>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="dictTypeId">字典类型Id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="key">key</param>
    public DictItem(Guid id, Guid dictTypeId, string name, string code, string key) : base(id, name, code)
    {
        DictTypeId = dictTypeId;
        Key = key;
    }

    /// <summary>
    /// 样式
    /// </summary>
    public string? Style { get; private set; }

    /// <summary>
    /// 设置样式
    /// </summary>
    /// <param name="style">样式</param>
    public void SetStyle(string? style)
    {
        Style = style;
    }

    /// <summary>
    /// 字典类型id
    /// </summary>
    public Guid DictTypeId { get; private set; }

    /// <summary>
    /// 键
    /// </summary>
    public string Key { get; private set; }

    /// <summary>
    /// 父级id
    /// </summary>
    public Guid? ParentId { get; private set; }

    /// <summary>
    /// 别名
    /// </summary>
    public string? Alias { get; private set; }

    /// <summary>
    /// 设置父级id
    /// </summary>
    /// <param name="parentId">父级id</param>
    public void SetParentId(Guid? parentId)
    {
        ParentId = parentId;
    }

    /// <summary>
    /// 设置别名
    /// </summary>
    /// <param name="alias">别名</param>
    public void SetAlias(string? alias)
    {
        Alias = alias;
    }
}