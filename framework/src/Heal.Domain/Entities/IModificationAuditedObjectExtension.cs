using Volo.Abp.Auditing;

namespace Heal.Domain.Entities;

/// <summary>
/// 修改审计对象扩展
/// </summary>
public interface IModificationAuditedObjectExtension : IModificationAuditedObject, IMayHaveModificationName
{
    /// <summary>
    /// 设置修改审计对象
    /// </summary>
    /// <param name="lastModifierId">最后修改人Id</param>
    /// <param name="lastModificationName">修改人名称</param>
    /// <param name="lastModificationTime">修改时间</param>
    void SetModification(Guid? lastModifierId, string? lastModificationName, DateTime lastModificationTime);
}