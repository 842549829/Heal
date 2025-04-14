namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 修改审计对象
/// </summary>
public interface IModificationAuditedObjectDto : IMayHaveModificationTimeDto, IMayHaveModificationDto;