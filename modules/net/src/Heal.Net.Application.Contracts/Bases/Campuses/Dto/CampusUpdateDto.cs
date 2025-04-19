using Heal.Application.Contracts.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses.Dto;

/// <summary>
/// 修改院区
/// </summary>
public class CampusUpdateDto : CampusCreateOrUpdateDto,
    IHasConcurrencyStampDto
{
    /// <summary>
    /// 迸发标记
    /// </summary>
    public required string ConcurrencyStamp { get; init; }
}