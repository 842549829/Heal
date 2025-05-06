using Heal.Application.Contracts.Dtos;
using Heal.Domain.Shared.Enums;

namespace Heal.Dict.Application.Contracts.Dictes.Dtos;

/// <summary>
/// 字典类型更新
/// </summary>
public class DictTypeUpdateDto : DictTypeCreateOrUpdateDtoBase, IHasConcurrencyStampDto
{
    /// <summary>
    /// 版本
    /// </summary>
    public required string ConcurrencyStamp { get; init; } 

    /// <summary>
    /// 状态
    /// </summary>
    public required Enable Status { get; init; }
}