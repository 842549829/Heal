using Heal.Net.Domain.Bases.Campuses.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// <see cref="IHealNetDbContext"/>
/// </summary>
public interface IHealNetDbContext : IIdentityDbContext
{
    /// <summary>
    /// Campus
    /// </summary>
    public DbSet<Campus> Campuses { get; set; }
}