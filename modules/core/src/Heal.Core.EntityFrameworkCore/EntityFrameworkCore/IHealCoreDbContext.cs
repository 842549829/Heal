using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Core.Domain.Bases.Departments.Entities;
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
    public DbSet<Campus> Campuses { get; }

    /// <summary>
    /// Department
    /// </summary>
    public DbSet<Department> Departments { get; }

    /// <summary>
    /// Doctor
    /// </summary>
    public DbSet<Doctor> Doctors { get; }

    /// <summary>
    /// Patient
    /// </summary>
    public DbSet<Patient> Patients { get; }

    /// <summary>
    /// UserCampus
    /// </summary>
    public DbSet<UserCampus> UserCampuses { get; }

    /// <summary>
    /// UserDepartment
    /// </summary>
    public DbSet<UserDepartment> UserDepartments { get; }
}