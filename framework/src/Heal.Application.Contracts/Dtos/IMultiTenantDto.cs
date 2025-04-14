namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 多租户
/// </summary>
public interface IMultiTenantDto
{
    /// <summary>
    /// 租户Id
    /// </summary>
    Guid? TenantId { get; }
}