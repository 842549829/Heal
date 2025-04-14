namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 可创建审计对象
/// </summary>
public interface ICreationAuditedObjectDto : IHasCreationTimeDto, IMayHaveCreatorDto;