using Volo.Abp.Auditing;

namespace Heal.Domain.Entities;

/// <summary>
/// 删除审计对象扩展
/// </summary>
public interface IDeletionAuditedObjectExtension : IDeletionAuditedObject, IMayHaveDeletionName
{
    /// <summary>
    /// 设置删除审计信息
    /// </summary>
    /// <param name="deleterId">删除人Id</param>
    /// <param name="deletionName">删除人名称</param>
    /// <param name="deletionTime">删除时间</param>
    void SetDeletion(Guid? deleterId, string? deletionName, DateTime deletionTime);
}