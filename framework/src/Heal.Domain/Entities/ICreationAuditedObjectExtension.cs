using Volo.Abp.Auditing;

namespace Heal.Domain.Entities;

/// <summary>
/// 创建审计对象扩展
/// </summary>
public interface ICreationAuditedObjectExtension : ICreationAuditedObject, IMayHaveCreatorName
{
    /// <summary>
    /// 设置创建者
    /// </summary>
    /// <param name="creatorId">创建人Id</param>
    /// <param name="creatorName">创建人姓名</param>
    /// <param name="creatTime">创建时间</param>
    void SetCreator(Guid? creatorId, string? creatorName, DateTime creatTime);
}