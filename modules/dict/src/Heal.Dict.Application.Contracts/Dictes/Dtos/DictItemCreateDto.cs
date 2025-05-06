namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典项创建
/// </summary>
public class DictItemCreateDto : DictItemCreateOrUpdateDtoBase
{
    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; }

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; init; }

    /// <summary>
    /// 字典类型Id
    /// </summary>
    public required Guid DictTypeId { get; init; }
}