namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 删除审计对象
/// </summary>
public interface IDeletionAuditedObjectDto : IMayHaveDeletionDto, IHasDeletionTimeDto;