using Heal.Core.Domain.Bases.Users.Entities;
using Heal.Domain.Shared.Constants;
using Heal.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Users
{
    /// <summary>
    /// 患者档案的实体映射
    /// </summary>
    public static class PatientManagementDbContextModelCreatingExtensions
    {
        /// <summary>
        /// 配置实体映射
        /// </summary>
        /// <param name="builder">ModelBuilder</param>
        public static void ConfigureHealPatientManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            if (builder.IsTenantOnlyDatabase())
            {
                return;
            }

            builder.Entity<Patient>(b =>
            {
                b.ToTable(AbpCommonDbProperties.DbTablePrefix + nameof(Patient), AbpCommonDbProperties.DbSchema,
                    x => { x.HasComment("患者"); });

                b.ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Guid>();

                b.Property(x => x.WorkUnit)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.WorkUnit))
                    .HasMaxLength(PatientConstants.MaxWorkUnitLength)
                    .HasComment("工作单位");

                b.Property(x => x.WorkUnitAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.WorkUnitAddress))
                    .HasMaxLength(PatientConstants.MaxWorkUnitAddressLength)
                    .HasComment("工作单位地址");

                b.Property(x => x.WorkUnitPhone)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.WorkUnitPhone))
                    .HasMaxLength(PatientConstants.MaxWorkUnitPhoneLength)
                    .HasComment("工作单位电话");

                b.Property(x => x.EmergencyContact)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.EmergencyContact))
                    .HasMaxLength(PatientConstants.MaxEmergencyContactLength)
                    .HasComment("紧急联系人");

                b.Property(x => x.EmergencyContactPhone)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.EmergencyContactPhone))
                    .HasMaxLength(PatientConstants.MaxEmergencyContactPhoneLength)
                    .HasComment("紧急联系人电话");

                b.Property(x => x.EmergencyContactRelationship)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.EmergencyContactRelationship))
                    .HasMaxLength(PatientConstants.MaxEmergencyContactRelationshipLength)
                    .HasComment("紧急联系人关系");

                b.Property(x => x.EmergencyContactAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.EmergencyContactAddress))
                    .HasMaxLength(PatientConstants.MaxEmergencyContactAddressLength)
                    .HasComment("紧急联系人地址");

                b.Property(x => x.Ethnicity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.Ethnicity))
                    .HasMaxLength(PatientConstants.MaxEthnicityLength)
                    .HasComment("民族");

                b.Property(x => x.PoliticalStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.PoliticalStatus))
                    .HasMaxLength(PatientConstants.MaxPoliticalStatusLength)
                    .HasComment("政治面貌");

                b.Property(x => x.Nationality)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.Nationality))
                    .HasMaxLength(PatientConstants.MaxNationalityLength)
                    .HasComment("国籍");

                b.Property(x => x.NativePlace)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.NativePlace))
                    .HasMaxLength(PatientConstants.MaxNativePlaceLength)
                    .HasComment("籍贯");

                b.Property(x => x.HealthStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.HealthStatus))
                    .HasMaxLength(PatientConstants.MaxHealthStatusLength)
                    .HasComment("健康状况");

                b.Property(x => x.MaritalStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.MaritalStatus))
                    .HasMaxLength(PatientConstants.MaxMaritalStatusLength)
                    .HasComment("婚姻状况");

                b.Property(x => x.BloodType)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.BloodType))
                    .HasMaxLength(PatientConstants.MaxBloodTypeLength)
                    .HasComment("血型");

                b.Property(x => x.CurrentAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.CurrentAddress))
                    .HasMaxLength(PatientConstants.MaxCurrentAddressLength)
                    .HasComment("现居住地址");

                b.Property(x => x.HouseholdAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.HouseholdAddress))
                    .HasMaxLength(PatientConstants.MaxHouseholdAddressLength)
                    .HasComment("户籍地址");

                b.Property(x => x.ResidencePermitAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.ResidencePermitAddress))
                    .HasMaxLength(PatientConstants.MaxResidencePermitAddressLength)
                    .HasComment("居住证地址");

                b.Property(x => x.ResidencePermitValidity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.ResidencePermitValidity))
                    .HasMaxLength(PatientConstants.MaxResidencePermitValidityLength)
                    .HasComment("居住证有效期");

                b.Property(x => x.IdCardValidity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardValidity))
                    .HasMaxLength(PatientConstants.MaxIdCardValidityLength)
                    .HasComment("身份证有效期");

                b.Property(x => x.IdCardAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardAddress))
                    .HasMaxLength(PatientConstants.MaxIdCardAddressLength)
                    .HasComment("身份证地址");

                b.Property(x => x.IdCardFrontPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardFrontPhoto))
                    .HasMaxLength(PatientConstants.MaxIdCardFrontPhotoLength)
                    .HasComment("身份证正面照");

                b.Property(x => x.IdCardBackPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardBackPhoto))
                    .HasMaxLength(PatientConstants.MaxIdCardBackPhotoLength)
                    .HasComment("身份证反面照");

                b.Property(x => x.IdCardEmblemPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardEmblemPhoto))
                    .HasMaxLength(PatientConstants.MaxIdCardEmblemPhotoLength)
                    .HasComment("身份证国徽照");

                b.Property(x => x.IdCardNumber)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.IdCardNumber))
                    .HasMaxLength(PatientConstants.MaxIdCardNumberLength)
                    .HasComment("身份证编号");

                b.Property(x => x.MedicalCardNumber)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.MedicalCardNumber))
                    .HasMaxLength(PatientConstants.MaxMedicalCardNumberLength)
                    .HasComment("医保卡号");

                b.Property(x => x.Source)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.Source))
                    .HasMaxLength(PatientConstants.MaxSourceLength)
                    .HasComment("来源");

                b.Property(x => x.GuardianId)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianId))
                    .HasMaxLength(PatientConstants.MaxGuardianIdLength)
                    .HasComment("监护人ID");

                b.Property(x => x.GuardianName)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianName))
                    .HasMaxLength(PatientConstants.MaxGuardianNameLength)
                    .HasComment("监护人姓名");

                b.Property(x => x.GuardianRelationship)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianRelationship))
                    .HasMaxLength(PatientConstants.MaxGuardianRelationshipLength)
                    .HasComment("监护人关系");

                b.Property(x => x.GuardianPhone)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianPhone))
                    .HasMaxLength(PatientConstants.MaxGuardianPhoneLength)
                    .HasComment("监护人电话");

                b.Property(x => x.GuardianAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianAddress))
                    .HasMaxLength(PatientConstants.MaxGuardianAddressLength)
                    .HasComment("监护人地址");

                b.Property(x => x.GuardianIdCard)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCard))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardLength)
                    .HasComment("监护人身份证");

                b.Property(x => x.GuardianGender)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianGender))
                    .HasMaxLength(PatientConstants.MaxGuardianGenderLength)
                    .HasComment("监护人性别");

                b.Property(x => x.GuardianEthnicity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianEthnicity))
                    .HasMaxLength(PatientConstants.MaxGuardianEthnicityLength)
                    .HasComment("监护人民族");

                b.Property(x => x.GuardianPoliticalStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianPoliticalStatus))
                    .HasMaxLength(PatientConstants.MaxGuardianPoliticalStatusLength)
                    .HasComment("监护人政治面貌");

                b.Property(x => x.GuardianNationality)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianNationality))
                    .HasMaxLength(PatientConstants.MaxGuardianNationalityLength)
                    .HasComment("监护人国籍");

                b.Property(x => x.GuardianNativePlace)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianNativePlace))
                    .HasMaxLength(PatientConstants.MaxGuardianNativePlaceLength)
                    .HasComment("监护人籍贯");

                b.Property(x => x.GuardianHealthStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianHealthStatus))
                    .HasMaxLength(PatientConstants.MaxGuardianHealthStatusLength)
                    .HasComment("监护人健康状况");

                b.Property(x => x.GuardianMaritalStatus)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianMaritalStatus))
                    .HasMaxLength(PatientConstants.MaxGuardianMaritalStatusLength)
                    .HasComment("监护人婚姻状况");

                b.Property(x => x.GuardianBloodType)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianBloodType))
                    .HasMaxLength(PatientConstants.MaxGuardianBloodTypeLength)
                    .HasComment("监护人血型");

                b.Property(x => x.GuardianCurrentAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianCurrentAddress))
                    .HasMaxLength(PatientConstants.MaxGuardianCurrentAddressLength)
                    .HasComment("监护人现居住地");

                b.Property(x => x.GuardianHouseholdAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianHouseholdAddress))
                    .HasMaxLength(PatientConstants.MaxGuardianHouseholdAddressLength)
                    .HasComment("监护人户籍地");

                b.Property(x => x.GuardianResidencePermitAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianResidencePermitAddress))
                    .HasMaxLength(PatientConstants.MaxGuardianResidencePermitAddressLength)
                    .HasComment("监护人居住证地址");

                b.Property(x => x.GuardianResidencePermitValidity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianResidencePermitValidity))
                    .HasMaxLength(PatientConstants.MaxGuardianResidencePermitValidityLength)
                    .HasComment("监护人居住证有效期");

                b.Property(x => x.GuardianIdCardValidity)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardValidity))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardValidityLength)
                    .HasComment("监护人身份证有效期");

                b.Property(x => x.GuardianIdCardAddress)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardAddress))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardAddressLength)
                    .HasComment("监护人身份证地址");

                b.Property(x => x.GuardianIdCardFrontPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardFrontPhoto))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardFrontPhotoLength)
                    .HasComment("监护人身份证正面照");

                b.Property(x => x.GuardianIdCardBackPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardBackPhoto))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardBackPhotoLength)
                    .HasComment("监护人身份证反面照");

                b.Property(x => x.GuardianIdCardEmblemPhoto)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardEmblemPhoto))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardEmblemPhotoLength)
                    .HasComment("监护人身份证国徽照");

                b.Property(x => x.GuardianIdCardBackPhotoDuplicate)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCardBackPhotoDuplicate))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardBackPhotoDuplicateLength)
                    .HasComment("监护人身份证反面照");

                b.Property(x => x.GuardianIdCard)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.GuardianIdCard))
                    .HasMaxLength(PatientConstants.MaxGuardianIdCardLength)
                    .HasComment("监护人身份证号");

                b.Property(x => x.MedicalRecordNumber)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.MedicalRecordNumber))
                    .HasMaxLength(PatientConstants.MaxMedicalRecordNumberLength)
                    .HasComment("病案号");

                b.Property(x => x.Alias)
                    .IsRequired(false)
                    .HasColumnName(nameof(Patient.Alias))
                    .HasMaxLength(PatientConstants.MaxAliasLength)
                    .HasComment("别名");

                b.Property(x => x.IsOpenLogin)
                    .IsRequired()
                    .HasColumnName(nameof(Patient.IsOpenLogin))
                    .HasComment("是否开通登录功能");

                b.HasIndex(x => x.Code);
                b.HasIndex(x => x.Name);
                b.HasIndex(x => x.Phone);
                b.HasIndex(x => x.IdCardNo);
            });
        }
    }
}