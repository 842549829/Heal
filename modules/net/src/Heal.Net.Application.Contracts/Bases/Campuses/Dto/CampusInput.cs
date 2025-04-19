using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Campuses.Dto;

/// <summary>
/// 获取校区列表
/// </summary>
public class CampusInput : ExtensiblePagedAndSortedResultRequestDto
{
    /// <summary>
    /// 过滤条件
    /// </summary>
    public string? Filter { get; set; }
}