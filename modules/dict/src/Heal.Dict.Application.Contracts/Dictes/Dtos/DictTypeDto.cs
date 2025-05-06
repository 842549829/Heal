using Heal.Application.Contracts.Dtos;
using Heal.Domain.Shared.Enums;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典类型
/// </summary>
public class DictTypeDto : ExtensibleEntityDto<Guid>, IHasConcurrencyStampDto
{
    /// <summary>
    /// 版本
    /// </summary>
    public required string ConcurrencyStamp { get; init; }

    /// <summary>
    /// 别名
    /// </summary>
    public string? Alias { get; init; }

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; init; }

    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; init; }

    /// <summary>
    /// 状态
    /// </summary>
    public Enable Status { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 描述
    /// </summary>
    public required string Describe { get; init; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; init; }
}