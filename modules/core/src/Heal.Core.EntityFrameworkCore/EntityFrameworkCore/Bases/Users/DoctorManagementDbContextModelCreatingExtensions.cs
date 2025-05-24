using Heal.Core.Domain.Bases.Users.Entities;
using Heal.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Users;

/// <summary>
/// UserManagementDbContextModelCreatingExtensions
/// </summary>
public static class DoctorManagementDbContextModelCreatingExtensions
{
    /// <summary>
    /// ConfigureHealUser
    /// </summary>
    /// <param name="builder">ModelBuilder</param>
    public static void ConfigureHealDoctor(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<Doctor>(b =>
        {
            b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(Doctor), AbpCommonDbProperties.DbSchema, x =>
            {
                x.HasComment("医生");
            });

            b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

            b.Property(x => x.Education)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.Education))
                .HasMaxLength(DoctorConstants.MaxEducationLength)
                .HasComment("学历");

            b.Property(x => x.MedicalSchool)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.MedicalSchool))
                .HasMaxLength(DoctorConstants.MaxMedicalSchoolLength)
                .HasComment("毕业院校");

            b.Property(x => x.Major)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.Major))
                .HasMaxLength(DoctorConstants.MaxMajorLength)
                .HasComment("专业");

            b.Property(x => x.GraduationDate)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.GraduationDate))
                .HasComment("毕业时间");

            b.Property(x => x.Avatar)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.Avatar))
                .HasMaxLength(DoctorConstants.MaxAvatarLength)
                .HasComment("头像");

            b.Property(x => x.PracticeLicenseNumber)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PracticeLicenseNumber))
                .HasMaxLength(DoctorConstants.MaxPracticeLicenseNumberLength)
                .HasComment("执业许可证编号");

            b.Property(x => x.PracticeScope)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PracticeScope))
                .HasMaxLength(DoctorConstants.MaxPracticeScopeLength)
                .HasComment("执业范围");

            b.Property(x => x.PracticeValidityDate)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PracticeValidityDate))
                .HasComment("执业有效期");

            b.Property(x => x.PracticeExperience)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PracticeExperience))
                .HasMaxLength(DoctorConstants.MaxPracticeExperienceLength)
                .HasComment("执业经历");

            b.Property(x => x.WorkAgeLimit)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.WorkAgeLimit))
                .HasMaxLength(DoctorConstants.MaxWorkAgeLimitLength)
                .HasComment("工作年限");

            b.Property(x => x.Specialization)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.Specialization))
                .HasMaxLength(DoctorConstants.MaxSpecializationLength)
                .HasComment("专长");

            b.Property(x => x.ResearchResult)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.ResearchResult))
                .HasMaxLength(DoctorConstants.MaxResearchResultLength)
                .HasComment("科研成果");

            b.Property(x => x.ProfessionalClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.ProfessionalClassify))
                .HasMaxLength(DoctorConstants.MaxProfessionalClassifyLength)
                .HasComment("专业分类");

            b.Property(x => x.EvaluateClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.EvaluateClassify))
                .HasMaxLength(DoctorConstants.MaxEvaluateClassifyLength)
                .HasComment("评价分类");

            b.Property(x => x.WorkClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.WorkClassify))
                .HasMaxLength(DoctorConstants.MaxWorkClassifyLength)
                .HasComment("工作分类");

            b.Property(x => x.PracticeClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PracticeClassify))
                .HasMaxLength(DoctorConstants.MaxPracticeClassifyLength)
                .HasComment("执业分类");

            b.Property(x => x.PeculiarityClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.PeculiarityClassify))
                .HasMaxLength(DoctorConstants.MaxPeculiarityClassifyLength)
                .HasComment("类型(按特质类型分类)");

            b.Property(x => x.ScopeClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.ScopeClassify))
                .HasMaxLength(DoctorConstants.MaxScopeClassifyLength)
                .HasComment("类型(按范围分类)");

            b.Property(x => x.OccupationClassify)
                .IsRequired(false)
                .HasColumnName(nameof(Doctor.OccupationClassify))
                .HasMaxLength(DoctorConstants.MaxOccupationClassifyLength)
                .HasComment("类型(按职业分类)");

            b.Property(x => x.IsOpenLogin)
                .IsRequired()
                .HasColumnName(nameof(Doctor.IsOpenLogin))
                .HasComment("是否开放登录");

            b.HasIndex(x => x.Code);
            b.HasIndex(x => x.Name);
            b.HasIndex(x => x.Phone);
            b.HasIndex(x => x.IdCardNo);
        });
    }
}