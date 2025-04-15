using Heal.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Heal.Net.Domain.Bases.Campuses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;

/// <summary>
/// 院区的模型创建扩展方法
/// </summary>
public static class CampusDbContextModelCreatingExtensions
{
    /// <summary>
    /// 院区的模型创建扩展方法
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureCampuses(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity(delegate (EntityTypeBuilder<Campus> b)
        {
            b.ToTable(AbpBackgroundJobsDbProperties.DbTablePrefix + "Campus", AbpBackgroundJobsDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot();

            b.Property(x => x.ShortName)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxShortNameLength);

            b.Property(x => x.ShortName)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxShortNameLength);

            b.Property(x => x.Building)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxBuildingLength);

            b.Property(x => x.Floor)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxFloorLength);

            b.Property(x => x.RoomNumber)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxRoomNumberLength);

            b.Property(x => x.Address)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxAddressLength);

            b.Property(x => x.Phone)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxPhoneLength);

            b.Property(x => x.Email)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxEmailLength);

            b.Property(x => x.HeadOfCampus)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxHeadOfCampusLength);

            b.Property(x => x.HeadOfCampusPhone)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxHeadOfCampusPhoneLength);

            b.Property(x => x.HeadOfCampusEmail)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxHeadOfCampusEmailLength);

            b.Property(x => x.Website)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxWebsiteLength);

            b.Property(x => x.ServicesOffered)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxServicesOfferedLength);

            b.Property(x => x.EmergencyContact)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxEmergencyContactLength);

            b.Property(x => x.EmergencyPhone)
                .IsRequired(false)
                .HasMaxLength(CampusConsts.MaxEmergencyPhoneLength);

            b.ApplyObjectExtensionMappings();
        });
        builder.TryConfigureObjectExtensions<BackgroundJobsDbContext>();
    }
}