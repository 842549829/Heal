using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;

/// <summary>
/// 院区的模型创建扩展方法
/// </summary>
public static class CampusDbContextModelCreatingExtensions
{
    /// <summary>
    /// 院区的模型创建扩展方法
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealCampuses(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<Campus>(b =>
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(Campus), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("院区");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.ShortName)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.ShortName))
                .HasMaxLength(CampusConstants.MaxShortNameLength)
                .HasComment("简称");

            b.Property(x => x.Building)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Building))
                .HasMaxLength(CampusConstants.MaxBuildingLength)
                .HasComment("所在大楼");

            b.Property(x => x.Floor)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Floor))
                .HasMaxLength(CampusConstants.MaxFloorLength)
                .HasComment("所在楼层");

            b.Property(x => x.RoomNumber)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.RoomNumber))
                .HasMaxLength(CampusConstants.MaxRoomNumberLength)
                .HasComment("所在房间");

            b.Property(x => x.Address)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Address))
                .HasMaxLength(CampusConstants.MaxAddressLength)
                .HasComment("所在详细地址");

            b.Property(x => x.Capacity)
                .IsRequired()
                .HasColumnName(nameof(Campus.Capacity))
                .HasComment("院区容量");

            b.Property(x => x.Phone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Phone))
                .HasMaxLength(CampusConstants.MaxPhoneLength)
                .HasComment("联系电话");

            b.Property(x => x.Email)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Email))
                .HasMaxLength(CampusConstants.MaxEmailLength)
                .HasComment("联系邮箱");

            b.Property(x => x.HeadOfCampus)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampus))
                .HasMaxLength(CampusConstants.MaxHeadOfCampusLength)
                .HasComment("院区负责人");

            b.Property(x => x.HeadOfCampusPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampusPhone))
                .HasMaxLength(CampusConstants.MaxHeadOfCampusPhoneLength)
                .HasComment("院区负责人电话");

            b.Property(x => x.HeadOfCampusEmail)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampusEmail))
                .HasMaxLength(CampusConstants.MaxHeadOfCampusEmailLength)
                .HasComment("院区负责人邮箱");

            b.Property(x => x.Website)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Website))
                .HasMaxLength(CampusConstants.MaxWebsiteLength)
                .HasComment("院区网站");

            b.Property(x => x.ServicesOffered)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.ServicesOffered))
                .HasMaxLength(CampusConstants.MaxServicesOfferedLength)
                .HasComment("院区提供的服务");

            b.Property(x => x.EmergencyContact)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.EmergencyContact))
                .HasMaxLength(CampusConstants.MaxEmergencyContactLength)
                .HasComment("紧急联系人名称");

            b.Property(x => x.EmergencyPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.EmergencyPhone))
                .HasMaxLength(CampusConstants.MaxEmergencyPhoneLength)
                .HasComment("紧急联系人电话");

            b.HasOne(e => e.OrganizationUnit)
                .WithMany()
                .HasForeignKey(e => e.OrganizationId);
        });

        builder.Entity<UserCampus>(b =>
        { 
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(UserCampus), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("用户院区");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(nameof(UserCampus.UserId))
                .HasComment("用户Id");

            b.Property(x => x.CampusId)
                .IsRequired()
                .HasColumnName(nameof(UserCampus.CampusId))
                .HasComment("院区Id");

            b.Property(x => x.TenantId)
                .IsRequired(false)
                .HasColumnName(nameof(UserCampus.TenantId))
                .HasComment("租户Id");

            b.HasKey(x => new { x.UserId, x.CampusId });
        });
    }
}