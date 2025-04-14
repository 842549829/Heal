using Heal.Domain.Repositories;
using Heal.Net.Domain.Bases.Campuses.Entities;
using Volo.Abp.Domain.Repositories;

namespace Heal.Net.Domain.Bases.Campuses.Repositories;

/// <summary>
/// 院区仓储接口
/// </summary>
public interface ICampusRepository : IHealRepository, IBasicRepository<Campus, Guid>
{
}