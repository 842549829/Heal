namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可有创建人
/// </summary>
public interface IMayHaveCreatorDto
{
    /// <summary>
    /// 创建人Id
    /// </summary>
    Guid? CreatorId { get; }
}