using Volo.Abp.MultiTenancy;

namespace Heal.Domain.Entities;

/// <summary>
/// 多租户扩展
/// </summary>
public interface IMultiTenantExtension : IMultiTenant
{
    /// <summary>
    /// 设置租户
    /// </summary>
    public void SetTenant(Guid? tenantId);
}