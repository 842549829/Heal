namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 创建字典类型
/// </summary>
public class DictTypeCreateDto : DictTypeCreateOrUpdateDtoBase
{
    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; init; } 

    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; init; }
}