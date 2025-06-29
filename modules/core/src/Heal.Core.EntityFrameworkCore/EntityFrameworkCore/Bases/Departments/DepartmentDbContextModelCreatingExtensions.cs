﻿using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Departments;

/// <summary>
/// 科室的模型创建扩展方法
/// </summary>
public static class DepartmentDbContextModelCreatingExtensions
{
    /// <summary>
    /// 科室的模型创建扩展方法
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealDepartment(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity(delegate(EntityTypeBuilder<Department> b)
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(Department), AbpCommonDbProperties.DbSchema,
                x => { x.HasComment("科室"); });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.CampusId)
                .IsRequired(false)
                .HasColumnName(nameof(Department.CampusId))
                .HasComment("所在院区Id");

            b.Property(x => x.ShortName)
                .IsRequired(false)
                .HasColumnName(nameof(Department.ShortName))
                .HasMaxLength(DepartmentConstants.MaxShortNameLength)
                .HasComment("简称");

            b.Property(x => x.DepartmentTypeId)
                .IsRequired()
                .HasColumnName(nameof(Department.DepartmentTypeId))
                .HasComment("科室类型Id");

            b.Property(x => x.Building)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Building))
                .HasMaxLength(DepartmentConstants.MaxBuildingLength)
                .HasComment("所在大楼");

            b.Property(x => x.Floor)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Floor))
                .HasMaxLength(DepartmentConstants.MaxFloorLength)
                .HasComment("所在楼层");

            b.Property(x => x.RoomNumber)
                .IsRequired(false)
                .HasColumnName(nameof(Department.RoomNumber))
                .HasMaxLength(DepartmentConstants.MaxRoomNumberLength)
                .HasComment("所在房间");

            b.Property(x => x.Address)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Address))
                .HasMaxLength(DepartmentConstants.MaxAddressLength)
                .HasComment("所在详细地址");

            b.Property(x => x.Capacity)
                .IsRequired()
                .HasColumnName(nameof(Department.Capacity))
                .HasComment("科室容量");

            b.Property(x => x.Phone)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Phone))
                .HasMaxLength(DepartmentConstants.MaxPhoneLength)
                .HasComment("联系电话");

            b.Property(x => x.Email)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Email))
                .HasMaxLength(DepartmentConstants.MaxEmailLength)
                .HasComment("联系邮箱");

            b.Property(x => x.HeadOfDepartment)
                .IsRequired(false)
                .HasColumnName(nameof(Department.HeadOfDepartment))
                .HasMaxLength(DepartmentConstants.MaxHeadOfDepartmentLength)
                .HasComment("科室负责人");

            b.Property(x => x.HeadOfDepartmentPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Department.HeadOfDepartmentPhone))
                .HasMaxLength(DepartmentConstants.MaxHeadOfDepartmentPhoneLength)
                .HasComment("科室负责人电话");

            b.Property(x => x.HeadOfDepartmentEmail)
                .IsRequired(false)
                .HasColumnName(nameof(Department.HeadOfDepartmentEmail))
                .HasMaxLength(DepartmentConstants.MaxHeadOfDepartmentEmailLength)
                .HasComment("科室负责人邮箱");

            b.Property(x => x.Website)
                .IsRequired(false)
                .HasColumnName(nameof(Department.Website))
                .HasMaxLength(DepartmentConstants.MaxWebsiteLength)
                .HasComment("科室网站");

            b.Property(x => x.ServicesOffered)
                .IsRequired(false)
                .HasColumnName(nameof(Department.ServicesOffered))
                .HasMaxLength(DepartmentConstants.MaxServicesOfferedLength)
                .HasComment("科室提供的服务");

            b.Property(x => x.EmergencyContact)
                .IsRequired(false)
                .HasColumnName(nameof(Department.EmergencyContact))
                .HasMaxLength(DepartmentConstants.MaxEmergencyContactLength)
                .HasComment("紧急联系人名称");

            b.Property(x => x.EmergencyPhone)
                .IsRequired(false)
                .HasColumnName(nameof(Department.EmergencyPhone))
                .HasMaxLength(DepartmentConstants.MaxEmergencyPhoneLength)
                .HasComment("紧急联系人电话");

            b.HasOne(e => e.Campus)
                .WithMany()
                .HasForeignKey(e => e.CampusId);

            //b.HasOne(e => e.DepartmentType)
            //    .WithMany()
            //    .HasForeignKey(e => e.DepartmentTypeId);
        });

        builder.Entity<UserDepartment>(b =>
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(UserDepartment), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("用户科室");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.UserId)
                .IsRequired()
                .HasColumnName(nameof(UserDepartment.UserId))
                .HasComment("用户Id");

            b.Property(x => x.DepartmentId)
                .IsRequired()
                .HasColumnName(nameof(UserDepartment.DepartmentId))
                .HasComment("科室Id");

            b.Property(x => x.TenantId)
                .IsRequired(false)
                .HasColumnName(nameof(UserDepartment.TenantId))
                .HasComment("租户Id");

            b.HasKey(x => new { x.UserId, x.DepartmentId });
        });
    }
}