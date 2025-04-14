using Heal.Net.Domain.Bases.Campuses.Entities;
using Heal.Net.Domain.Bases.Campuses.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;

/// <summary>
/// Repository
/// </summary>
/// <param name="dbContextProvider">IHealNetDbContext</param>
public class CampusRepository(IDbContextProvider<IHealNetDbContext> dbContextProvider)
    : EfCoreRepository<IHealNetDbContext, Campus, Guid>(dbContextProvider), ICampusRepository;