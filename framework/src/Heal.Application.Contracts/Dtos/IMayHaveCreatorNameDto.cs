namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可有创建人名称
/// </summary>
public interface IMayHaveCreatorNameDto
{
    /// <summary>
    /// 创建人名称
    /// </summary>
    string? CreatorName { get; }
}