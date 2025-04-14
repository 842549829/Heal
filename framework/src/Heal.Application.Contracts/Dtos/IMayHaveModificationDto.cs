namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可有最后修改人
/// </summary>
public interface IMayHaveModificationDto
{
    /// <summary>
    /// 最后修改人Id
    /// </summary>
    Guid? LastModifierId { get; }
}