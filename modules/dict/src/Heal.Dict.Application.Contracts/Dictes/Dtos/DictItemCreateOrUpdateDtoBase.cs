using Volo.Abp.ObjectExtending;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典项创建或更新DTO
/// </summary>
public class DictItemCreateOrUpdateDtoBase : ExtensibleObject
{
    /// <summary>
    /// 样式 
    /// </summary>
    public string? Style { get; init; }

    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; init; } 

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; init; }

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; init; }

    /// <summary>
    /// 别名
    /// </summary>
    public string? Alias { get; init; }
}