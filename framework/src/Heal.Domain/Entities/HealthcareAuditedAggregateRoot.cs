using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Extensions;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Heal.Domain.Entities;

/// <summary>
/// 基础聚合根
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">code</param>
public abstract class HealthcareAuditedAggregateRoot<TKey>(TKey id, string name, string code) :
    FullAuditedAggregateRoot<TKey>(id),
    ICreationAuditedObjectExtension,
    IModificationAuditedObjectExtension,
    IDeletionAuditedObjectExtension,
    IMultiTenantExtension,
    IHasEnableExtension,
    IHasSortExtension,
    IHasNamePinyin,
    IHasNameExtension,
    IHasCodeExtension,
    IMayHaveDescribeExtension
{
    /// <summary>
    /// 基础聚合根
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    protected HealthcareAuditedAggregateRoot(TKey id, string name) : this(id, name, string.Empty)
    {
    }

    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; private set; }

    /// <summary>
    /// 设置租户Id
    /// </summary>
    /// <param name="tenantId">租户Id</param>
    public void SetTenant(Guid? tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; private set; } = code;

    /// <summary>
    /// 设置编码
    /// </summary>
    /// <param name="code">编码</param>
    public void SetCode(string code)
    {
        Code = code;
    }

    /// <summary>
    /// 拼音
    /// </summary>
    public string Pinyin { get; private set; } = PinyinExtension.GetPinyin(name);

    /// <summary>
    /// 拼音首字母
    /// </summary>
    public string PinyinFirstLetters { get; private set; } = PinyinExtension.GetFirstPinyin(name);

    /// <summary>
    /// 状态
    /// </summary>
    public Enable Status { get; private set; } = Enable.Enabled;

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; private set; }

    /// <summary>
    /// 创建人姓名
    /// </summary>
    public string? CreatorName { get; private set; }

    /// <summary>
    /// 设置创建者
    /// </summary>
    /// <param name="creatorId">创建人Id</param>
    /// <param name="creatorName">创建人姓名</param>
    /// <param name="creatTime">创建时间</param>
    public void SetCreator(Guid? creatorId, string? creatorName, DateTime creatTime)
    {
        Check.NotNull(creatTime, nameof(creatTime));
        CreatorId = creatorId;
        CreatorName = creatorName;
        CreationTime = creatTime;
    }

    /// <summary>
    /// 最后修改人姓名
    /// </summary>
    public string? LastModificationName { get; private set; }

    /// <summary>
    /// 设置修改审计对象
    /// </summary>
    /// <param name="lastModifierId">最后修改人Id</param>
    /// <param name="lastModificationName">修改人名称</param>
    /// <param name="lastModificationTime">修改时间</param>
    public void SetModification(Guid? lastModifierId, string? lastModificationName, DateTime lastModificationTime)
    {
        Check.NotNull(lastModificationTime, nameof(lastModificationTime));
        LastModifierId = lastModifierId;
        LastModificationName = lastModificationName;
        LastModificationTime = lastModificationTime;
    }

    /// <summary>
    /// 删除人姓名
    /// </summary>
    public string? DeletionName { get; private set; }

    /// <summary>
    /// 设置删除审计信息
    /// </summary>
    /// <param name="deleterId">删除人Id</param>
    /// <param name="deletionName">删除人名称</param>
    /// <param name="deletionTime">删除时间</param>
    public void SetDeletion(Guid? deleterId, string? deletionName, DateTime deletionTime)
    {
        Check.NotNull(deletionTime, nameof(deletionTime));
        DeleterId = deleterId;
        DeletionName = deletionName;
        DeletionTime = deletionTime;
    }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; private set; }

    /// <summary>
    /// 设置描述
    /// </summary>
    /// <param name="describe">描述</param>
    public void SetDescribe(string? describe)
    {
        Describe = describe;
    }

    /// <summary>
    /// 设置排序
    /// </summary>
    /// <param name="sort">排序</param>
    public void SetSort(int sort)
    {
        Sort = sort;
    }

    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="status">状态</param>
    public void SetStatus(Enable status)
    {
        Status = status;
    }

    /// <summary>
    /// 设置名称
    /// </summary>
    /// <param name="name">名称</param>
    public void SetName(string name)
    {
        Check.NotNull(name, nameof(name));
        Name = name;
        Pinyin = PinyinExtension.GetPinyin(name);
        PinyinFirstLetters = PinyinExtension.GetFirstPinyin(name);
    }

    /// <summary>
    /// 设置并发版本
    /// </summary>
    /// <param name="concurrencyStamp">并发版本</param>
    public void SetConcurrencyStamp(string concurrencyStamp)
    {
        ConcurrencyStamp = concurrencyStamp;
    }
}