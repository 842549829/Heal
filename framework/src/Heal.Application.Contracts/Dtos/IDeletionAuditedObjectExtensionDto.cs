namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 扩展删除审计对象
/// </summary>
public interface IDeletionAuditedObjectExtensionDto : IDeletionAuditedObjectDto, IMayHaveDeletionNameDto;