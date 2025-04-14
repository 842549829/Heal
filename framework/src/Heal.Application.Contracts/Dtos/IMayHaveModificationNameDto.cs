namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可修改人名称
/// </summary>
public interface IMayHaveModificationNameDto
{
    /// <summary>
    /// 修改人名称
    /// </summary>
    string? LastModificationName { get; }
}