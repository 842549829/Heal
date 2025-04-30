using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Core.Domain.Bases.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// <see cref="IHealCoreDbContext"/>
/// </summary>
public interface IHealCoreDbContext : IIdentityDbContext
{
    /// <summary>
    /// Campus
    /// </summary>
    public DbSet<Campus> Campuses { get; set; }

    /// <summary>
    /// Doctor
    /// </summary>
    public DbSet<Doctor> Doctors { get; set;}

    /// <summary>
    /// Patient
    /// </summary>
    public DbSet<Patient> Patients { get; set; }
}