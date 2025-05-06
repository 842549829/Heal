using Heal.Application.Contracts.Dtos;
using Heal.Domain.Shared.Enums;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典项
/// </summary>
public class DictItemDto : ExtensibleEntityDto<Guid>, IHasConcurrencyStampDto
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public required Guid DictTypeId { get; init; }

    /// <summary>
    /// 乐观并发戳
    /// </summary>
    public required string ConcurrencyStamp { get; init; }

    /// <summary>
    /// 样式
    /// </summary>
    public string? Style { get; init; }

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
    public required Enable Status { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// 描述
    /// </summary>

    public string? Describe { get; init; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; init; }

    /// <summary>
    /// 别名
    /// </summary>
    public string? Alias { get; init; }
}