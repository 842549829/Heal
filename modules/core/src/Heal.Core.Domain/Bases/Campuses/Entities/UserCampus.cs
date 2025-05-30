using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Heal.Core.Domain.Bases.Campuses.Entities;

/// <summary>
/// 用户院区
/// </summary>
public class UserCampus : CreationAuditedEntity, IMultiTenant
{
    /// <summary>
    /// Constructor.
    /// </summary>
    protected UserCampus()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="campusId">院区Id</param>
    /// <param name="tenantId">租户Id</param>
    public UserCampus(Guid userId, Guid campusId, Guid? tenantId = null)
    {
        UserId = userId;
        CampusId = campusId;
        TenantId = tenantId;
    }

    /// <summary>
    /// UserId of the User.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// CampusId of the related <see cref="Campus"/>.
    /// </summary>
    public Guid CampusId { get; protected set; }

    /// <summary>Returns an array of ordered keys for this entity.</summary>
    /// <returns></returns>
    public override object?[] GetKeys()
    {
        return [UserId, CampusId];
    }

    /// <summary>
    /// TenantId of this entity.
    /// </summary>
    public Guid? TenantId { get; protected set; }
}