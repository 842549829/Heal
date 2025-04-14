namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 组织Id
/// </summary>
public interface IHasOrganizationDto
{
    /// <summary>
    /// 组织Id
    /// </summary>
    Guid OrganizationId { get; }
}