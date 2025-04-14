namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 修改扩展属性
/// </summary>
public interface IModificationAuditedObjectExtensionDto: IModificationAuditedObjectDto, IMayHaveModificationNameDto;