namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 扩展创建审计对象
/// </summary>
public interface ICreationAuditedObjectExtensionDto : ICreationAuditedObjectDto, IMayHaveCreatorNameDto;