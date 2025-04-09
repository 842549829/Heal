using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 组织机构
/// </summary>
public class OrganizationDto : ExtensibleFullAuditedEntityDto<Guid>, IMultiTenant, IHasConcurrencyStamp
{
    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// 版本
    /// </summary>
    public required string ConcurrencyStamp { get; set; }

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public required string DisplayName { get; set; }
}