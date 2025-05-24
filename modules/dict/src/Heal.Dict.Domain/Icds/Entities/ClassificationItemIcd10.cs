using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// ICD-10 分类项目
/// </summary>
public class ClassificationItemIcd10 : HealthcareAuditedAggregateRoot<Guid>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="classificationId">所属分类Id</param>
    public ClassificationItemIcd10(Guid id, string name, string code, Guid classificationId) : base(id, name, code)
    {
        ClassificationId = classificationId;
    }

    /// <summary>
    /// 所属分类Id
    /// </summary>
    public Guid ClassificationId { get; private set; }

    /// <summary>
    /// 设置所属分类Id
    /// </summary>
    /// <param name="classificationId">所属分类Id</param>
    public void SetClassificationId(Guid classificationId)
    {
        ClassificationId = classificationId;
    }

    /// <summary>
    /// 所属分类
    /// </summary>
    public virtual ClassificationIcd10 Classification { get; private set; } = null!;
}