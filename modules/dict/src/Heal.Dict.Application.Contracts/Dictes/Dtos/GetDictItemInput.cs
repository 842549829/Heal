using Heal.Application.Contracts.Dtos;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 获取字典项的输入
/// </summary>
public class GetDictItemInput : FilterInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public required Guid DictTypeId { get; init; }
}