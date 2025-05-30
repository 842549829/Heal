using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Heal.Core.Domain.Bases.Departments.Entities;

/// <summary>
/// 用户科室
/// </summary>
public class UserDepartment : CreationAuditedEntity, IMultiTenant
{
    /// <summary>
    /// Constructor.
    /// </summary>
    protected UserDepartment()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="departmentId">科室Id</param>
    /// <param name="tenantId">租户Id</param>
    public UserDepartment(Guid userId, Guid departmentId, Guid? tenantId = null)
    {
        UserId = userId;
        DepartmentId = departmentId;
        TenantId = tenantId;
    }

    /// <summary>
    /// UserId of the User.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// DepartmentId of the related <see cref="Department"/>.
    /// </summary>
    public Guid DepartmentId { get; protected set; }

    /// <summary>Returns an array of ordered keys for this entity.</summary>
    /// <returns></returns>
    public override object?[] GetKeys()
    {
        return [UserId, DepartmentId];
    }

    /// <summary>
    /// TenantId of this entity.
    /// </summary>
    public Guid? TenantId { get; protected set; }
}