using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Organizations.Dtos;

/// <summary>
/// 组织选择
/// </summary>
public class OrganizationSelectDto : EntityDto<Guid>
{
    /// <summary>
    /// 编码
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public required string DisplayName { get; set; }
    
    /// <summary>
    /// 父级Id
    /// </summary>
    public Guid? ParentId { get; set; }
}