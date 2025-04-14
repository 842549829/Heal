using Volo.Abp.Application.Dtos;

namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 带扩展属性的审计实体
/// </summary>
public abstract class AuditedEntityExtensionDto : AuditedEntityDto, ICreationAuditedObjectExtensionDto, IModificationAuditedObjectExtensionDto
{
    /// <summary>
    /// 创建人名称
    /// </summary>
    public string? CreatorName { get; set; }

    /// <summary>
    /// 修改人名称
    /// </summary>
    public string? LastModificationName { get; set; }
}

/// <summary>
/// 带扩展属性的审计实体
/// </summary>
public abstract class AuditedEntityExtensionDto<TPrimaryKey> : AuditedEntityDto<TPrimaryKey>, ICreationAuditedObjectExtensionDto, IModificationAuditedObjectExtensionDto
{
    /// <summary>
    /// 创建人名称
    /// </summary>
    public string? CreatorName { get; set; }

    /// <summary>
    /// 修改人名称
    /// </summary>
    public string? LastModificationName { get; set; }
}