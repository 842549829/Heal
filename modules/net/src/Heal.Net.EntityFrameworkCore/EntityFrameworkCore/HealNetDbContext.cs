using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Core.Domain.Bases.Users.Entities;
using Heal.Core.EntityFrameworkCore.EntityFrameworkCore;
using Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;
using Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Departments;
using Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Identities;
using Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Users;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.AuditLoggings;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.BackgroundJobs;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.BlobStorings;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Features;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.OpenIddicts;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Permissions;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Settings;
using Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Tenants;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// Entity Framework Core implementation of HealNetDbContext.
/// </summary>
[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ReplaceDbContext(typeof(IHealNetDbContext))]
[ReplaceDbContext(typeof(IHealCoreDbContext))]
[ConnectionStringName("Default")]
public class HealNetDbContext :
    AbpDbContext<HealNetDbContext>,
    ITenantManagementDbContext,
    IHealNetDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */


    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    /// <summary>
    /// IdentityUser
    /// </summary>
    public DbSet<IdentityUser> Users { get; set; }

    /// <summary>
    /// IdentityRole
    /// </summary>
    public DbSet<IdentityRole> Roles { get; set; }

    /// <summary>
    /// IdentityClaimType
    /// </summary>
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }

    /// <summary>
    /// OrganizationUnit
    /// </summary>
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }

    /// <summary>
    /// IdentitySecurityLog
    /// </summary>
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }

    /// <summary>
    /// IdentityLinkUser
    /// </summary>
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    /// <summary>
    /// IdentityUserDelegation
    /// </summary>
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    /// <summary>
    /// IdentitySession
    /// </summary>
    public DbSet<IdentitySession> Sessions { get; set; }

    /// <summary>
    /// Tenant
    /// </summary>
    public DbSet<Tenant> Tenants { get; set; }

    /// <summary>
    /// TenantConnectionString
    /// </summary>
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    /// <summary>
    /// Campus
    /// </summary>
    public DbSet<Campus> Campuses { get; set; }

    /// <summary>
    /// Doctor
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }

    /// <summary>
    /// Patient
    /// </summary>
    public DbSet<Patient> Patients { get; set; }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options">options</param>
    public HealNetDbContext(DbContextOptions<HealNetDbContext> options)
        : base(options)
    {

    }

    /// <summary>
    /// Configure the model here or remove if not needed.
    /// </summary>
    /// <param name="builder">builder</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureHealPermissionManagement();
        builder.ConfigureHealSettingManagement();
        builder.ConfigureHealBackgroundJobs();
        builder.ConfigureHealAuditLogging();
        builder.ConfigureHealFeatureManagement();
        builder.ConfigureHealIdentity();
        builder.ConfigureHealOpenIddict();
        builder.ConfigureHealTenantManagement();
        builder.ConfigureHealBlobStoring();
        builder.ConfigureHealCampuses();
        builder.ConfigureHealDepartment();
        builder.ConfigureHealPatientManagement();
        builder.ConfigureHealDoctor();
    }
}