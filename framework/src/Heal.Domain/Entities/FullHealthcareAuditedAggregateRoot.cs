namespace Heal.Domain.Entities;

/// <summary>
/// 带组织信息的聚合根
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">code</param>
public abstract class FullHealthcareAuditedAggregateRoot<TKey>(TKey id, string name, string code) : HealthcareAuditedAggregateRoot<TKey>(id, name, code),
    IHasOrganizationExtension
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    protected FullHealthcareAuditedAggregateRoot(TKey id, string name) : this(id, name, string.Empty)
    {
    }

    /// <summary>
    /// 组织id
    /// </summary>
    public Guid OrganizationId { get; private set; }

    /// <summary>
    /// 设置组织id
    /// </summary>
    /// <param name="organizationId">组织Id</param>
    public void SetOrganization(Guid organizationId)
    {
        OrganizationId = organizationId;
    }
}