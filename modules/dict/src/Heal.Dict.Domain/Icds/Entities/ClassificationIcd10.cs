using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// 诊断分类
/// </summary>
public class ClassificationIcd10 : HealthcareAuditedAggregateRoot<Guid>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    public ClassificationIcd10(Guid id, string name, string code) : base(id, name, code)
    {
    }
}