using Heal.Net.Domain.Bases.Campuses.Entities;
using Heal.Net.Domain.Bases.Users.Entities;
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

    /// <summary>
    /// Doctor
    /// </summary>
    public DbSet<Doctor> Doctors { get; set;}

    /// <summary>
    /// Patient
    /// </summary>
    public DbSet<Patient> Patients { get; set; }
}