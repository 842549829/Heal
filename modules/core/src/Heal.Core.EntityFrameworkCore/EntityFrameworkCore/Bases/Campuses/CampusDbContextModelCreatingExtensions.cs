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
                .HasMaxLength(CampusConsts.MaxShortNameLength)
                .HasComment("简称");

            b.Property(x => x.Building)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Building))
                .HasMaxLength(CampusConsts.MaxBuildingLength)
                .HasComment("所在大楼");

            b.Property(x => x.Floor)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Floor))
                .HasMaxLength(CampusConsts.MaxFloorLength)
                .HasComment("所在楼层");

            b.Property(x => x.RoomNumber)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.RoomNumber))
                .HasMaxLength(CampusConsts.MaxRoomNumberLength)
                .HasComment("所在房间");

            b.Property(x => x.Address)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Address))
                .HasMaxLength(CampusConsts.MaxAddressLength)
                .HasComment("所在详细地址");

            b.Property(x => x.Capacity)
                .IsRequired()
                .HasColumnName(nameof(Campus.Capacity))
                .HasComment("院区容量");

            b.Property(x => x.Phone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Phone))
                .HasMaxLength(CampusConsts.MaxPhoneLength)
                .HasComment("联系电话");

            b.Property(x => x.Email)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Email))
                .HasMaxLength(CampusConsts.MaxEmailLength)
                .HasComment("联系邮箱");

            b.Property(x => x.HeadOfCampus)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampus))
                .HasMaxLength(CampusConsts.MaxHeadOfCampusLength)
                .HasComment("院区负责人");

            b.Property(x => x.HeadOfCampusPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampusPhone))
                .HasMaxLength(CampusConsts.MaxHeadOfCampusPhoneLength)
                .HasComment("院区负责人电话");

            b.Property(x => x.HeadOfCampusEmail)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.HeadOfCampusEmail))
                .HasMaxLength(CampusConsts.MaxHeadOfCampusEmailLength)
                .HasComment("院区负责人邮箱");

            b.Property(x => x.Website)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.Website))
                .HasMaxLength(CampusConsts.MaxWebsiteLength)
                .HasComment("院区网站");

            b.Property(x => x.ServicesOffered)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.ServicesOffered))
                .HasMaxLength(CampusConsts.MaxServicesOfferedLength)
                .HasComment("院区提供的服务");

            b.Property(x => x.EmergencyContact)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.EmergencyContact))
                .HasMaxLength(CampusConsts.MaxEmergencyContactLength)
                .HasComment("紧急联系人名称");

            b.Property(x => x.EmergencyPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Campus.EmergencyPhone))
                .HasMaxLength(CampusConsts.MaxEmergencyPhoneLength)
                .HasComment("紧急联系人电话");

            b.HasOne(e => e.OrganizationUnit)
                .WithMany()
                .HasForeignKey(e => e.OrganizationId);
        });
    }
}