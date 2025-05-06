using Volo.Abp.ObjectExtending;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典类型创建或更新Dto
/// </summary>
public class DictTypeCreateOrUpdateDtoBase : ExtensibleObject
{
    /// <summary>
    /// 名称
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string? Describe { get; set; } 

    /// <summary>
    /// 排序
    /// </summary>
    public required int Sort { get; set; }
}