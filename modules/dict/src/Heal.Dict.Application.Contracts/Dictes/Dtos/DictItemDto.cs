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
    public required Guid DictTypeId { get; set; }

    /// <summary>
    /// 乐观并发戳
    /// </summary>
    public required string ConcurrencyStamp { get; set; }

    /// <summary>
    /// 样式
    /// </summary>
    public string? Style { get; set; }

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// 租户Id
    /// </summary>
    public Guid? TenantId { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public required Enable Status { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>

    public string? Describe { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; set; }

    /// <summary>
    /// 别名
    /// </summary>
    public string? Alias { get; set; }
}