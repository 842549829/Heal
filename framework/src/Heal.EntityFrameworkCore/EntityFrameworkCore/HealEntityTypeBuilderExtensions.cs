using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// EntityTypeBuilder扩展
/// </summary>
public static class HealEntityTypeBuilderExtensions
{
    /// <summary>
    /// 配置实体
    /// </summary>
    /// <typeparam name="Tkey">主键类型</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureByConvention<Tkey>(this EntityTypeBuilder b)
    {
        b.ConfigureByConvention();

        b.ConfigureByConventionBase<Tkey>();

        b.ApplyObjectExtensionMappings();
    }

    /// <summary>
    /// 配置实体
    /// </summary>
    /// <typeparam name="Tkey">主键类型</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureByConventionBase<Tkey>(this EntityTypeBuilder b)
    {
        b.TryConfigureId<Tkey>();
        b.TryConfigureConcurrencyStamp();
        b.TryConfigureCreationTime();
        b.TryConfigureLastModificationTime();
        b.TryConfigureDeletionTime();
        b.TryConfigureObjectExtensions();
        b.TryConfigureSoftDelete();
        b.TryConfigureModificationAudited();
        b.TryConfigureDeletionAudited();
        b.TryConfigureMayHaveCreator();
        b.TryConfigureMustHaveCreator();
        b.TryConfigureMultiTenant();
    }

    /// <summary>
    /// 配置实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureByConventionByHealthcareAuditedAggregateRoot<Tkey>(this EntityTypeBuilder b)
    {
        b.ConfigureByConvention<Tkey>();
        b.TryConfigureCode();
        b.TryConfigureCreatorName();
        b.TryConfigureModificationName();
        b.TryConfigureDeletionName();
        b.TryConfigureEnable();
        b.TryConfigureSort();
        b.TryConfigureName();
        b.TryConfigureDescribe();
        b.TryConfigureNamePinyin();
        b.TryConfigureNamePinyinFirstLetters();
    }

    /// <summary>
    /// 配置实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureByConventionByFullHealthcareAuditedAggregateRoot<Tkey>(this EntityTypeBuilder b)
    {
        b.ConfigureByConventionByHealthcareAuditedAggregateRoot<Tkey>();
        b.TryConfigureOrganizationId();
        b.TryConfigureOrganizationCode();
        b.TryConfigureParentId();
        b.TryConfigureIdCard();
        b.TryConfigureAge();
        b.TryConfigureAddress();
        b.TryConfigureUserBaseInfo();
    }

    /// <summary>
    /// 配置用户信息实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureUserBaseInfo(this EntityTypeBuilder b)
    {
        if (!b.Metadata.ClrType.IsAssignableTo<IHasUserBaseInfo>())
        {
            return;
        }

        b.Property(nameof(IHasUserBaseInfo.Name))
            .IsRequired()
            .HasMaxLength(UserConsts.MaxUserNameLength)
            .HasComment("名称");

        b.Property(nameof(IHasUserBaseInfo.Gender))
            .IsRequired(false)
            .HasMaxLength(UserConsts.MaxGenderLength)
            .HasComment("性别");

        b.Property(nameof(IHasUserBaseInfo.Birthday))
            .IsRequired()
            .HasComment("生日");

        b.Property(nameof(IHasUserBaseInfo.Phone))
            .IsRequired()
            .HasMaxLength(UserConsts.MaxPhoneLength)
            .HasComment("手机");

        b.Property(nameof(IHasUserBaseInfo.Email))
            .IsRequired()
            .HasMaxLength(UserConsts.MaxEmailLength)
            .HasComment("邮箱");
    }

    /// <summary>
    /// 配置地址实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureAddress(this EntityTypeBuilder b)
    {
        if (!b.Metadata.ClrType.IsAssignableTo<IMayHaveAddress>())
        {
            return;
        }

        b.Property(nameof(IMayHaveAddress.NationCode))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxNationCodeLength)
            .HasComment("国家代码");

        b.Property(nameof(IMayHaveAddress.ProvinceCode))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxProvinceCodeLength)
            .HasComment("省份代码");

        b.Property(nameof(IMayHaveAddress.CityCode))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxCityCodeLength)
            .HasComment("城市代码");

        b.Property(nameof(IMayHaveAddress.DistrictCode))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxDistrictCodeLength)
            .HasComment("区县代码");

        b.Property(nameof(IMayHaveAddress.Street))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxStreetLength)
            .HasComment("街道");

        b.Property(nameof(IMayHaveAddress.AddressLine))
            .IsRequired(false)
            .HasMaxLength(AddressConsts.MaxAddressLineLength)
            .HasComment("详细地址");
    }

    /// <summary>
    /// 配置年龄实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureAge(this EntityTypeBuilder b)
    {
        if (!b.Metadata.ClrType.IsAssignableTo<IMayHaveAge>())
        {
            return;
        }

        b.Property(nameof(IMayHaveAge.Year))
            .IsRequired()
            .HasComment(AgeConsts.Year);

        b.Property(nameof(IMayHaveAge.Month))
            .IsRequired()
            .HasComment(AgeConsts.Month);

        b.Property(nameof(IMayHaveAge.Day))
            .IsRequired()
            .HasComment(AgeConsts.Day);
    }

    /// <summary>
    /// 配置证件实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureIdCard(this EntityTypeBuilder b)
    {
        if (!b.Metadata.ClrType.IsAssignableTo<IHasIdCard>())
        {
            return;
        }

        b.Property(nameof(IHasIdCard.IdCardNo))
            .IsRequired()
            .HasMaxLength(IdCardConsts.MaxIdCardNoLength)
            .HasComment("证件号");

        b.Property(nameof(IHasIdCard.IdCardType))
            .IsRequired()
            .HasMaxLength(IdCardConsts.MaxIdCardTypeLength)
            .HasComment("证件类型");
    }

    /// <summary>
    /// 配置Id
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureId<Tkey>(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<Entity<Tkey>>())
        {
            b.Property(nameof(Entity<Guid>.Id))
                .HasComment("Id");
        }
    }

    /// <summary>
    /// 配置Code
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureCode(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasCode>())
        {
            b.Property(nameof(IHasCode.Code))
                .IsRequired()
                .HasMaxLength(CodeConsts.MaxLength)
                .HasColumnName(nameof(IHasCode.Code))
                .HasComment("编码");
        }
    }

    /// <summary>
    /// 配置ConcurrencyStamp
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureConcurrencyStamp(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasConcurrencyStamp>())
        {
            b.Property(nameof(IHasConcurrencyStamp.ConcurrencyStamp))
                .HasComment("迸发标记");
        }
    }

    /// <summary>
    /// 配置扩展字段
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureObjectExtensions(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasExtraProperties>())
        {
            b.Property<ExtraPropertyDictionary>(nameof(IHasExtraProperties.ExtraProperties))
                .HasComment("扩展字段");
        }
    }

    /// <summary>
    /// 配置软删除
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureSoftDelete(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<ISoftDelete>())
        {
            b.Property(nameof(ISoftDelete.IsDeleted))
                .HasComment("删除标记");
        }
    }

    /// <summary>
    /// 配置删除时间
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureDeletionTime(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasDeletionTime>())
        {
            b.Property(nameof(IHasDeletionTime.DeletionTime))
                .HasComment("删除时间");
        }
    }

    /// <summary>
    /// 配置创建人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureMayHaveCreator(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveCreator>())
        {
            b.Property(nameof(IMayHaveCreator.CreatorId))
                .HasComment("创建人Id");
        }
    }

    /// <summary>
    /// 配置创建人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureMustHaveCreator(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMustHaveCreator>())
        {
            b.Property(nameof(IMustHaveCreator.CreatorId))
                .HasComment("创建人Id");
        }
    }

    /// <summary>
    /// 配置删除人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureDeletionAudited(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IDeletionAuditedObject>())
        {
            b.Property(nameof(IDeletionAuditedObject.DeleterId))
                .HasComment("删除人Id");
        }
    }

    /// <summary>
    /// 配置创建时间
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureCreationTime(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasCreationTime>())
        {
            b.Property(nameof(IHasCreationTime.CreationTime))
                .HasComment("创建时间");
        }
    }

    /// <summary>
    /// 配置最后更新时间
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureLastModificationTime(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasModificationTime>())
        {
            b.Property(nameof(IHasModificationTime.LastModificationTime))
                .HasComment("最后更新时间");
        }
    }

    /// <summary>
    /// 配置最后更新人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureModificationAudited(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IModificationAuditedObject>())
        {
            b.Property(nameof(IModificationAuditedObject.LastModifierId))
                .HasComment("最后更新人");
        }
    }

    /// <summary>
    /// 配置多租户
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureMultiTenant(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMultiTenant>())
        {
            b.Property(nameof(IMultiTenant.TenantId))
                .HasComment("租户Id");
        }
    }

    /// <summary>
    /// 配置ParentId
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureParentId<T>(this EntityTypeBuilder<T> b)
        where T : class, IMayHaveParentId
    {
        b.As<EntityTypeBuilder>().TryConfigureParentId();
    }

    /// <summary>
    /// 配置ParentId
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureParentId(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveParentId>())
        {
            b.Property(nameof(IMayHaveParentId.ParentId))
                .IsConcurrencyToken()
                .IsRequired(false)
                .HasColumnName(nameof(IMayHaveParentId.ParentId))
                .HasComment("父级Id");
        }
    }

    /// <summary>
    /// 配置组织Code
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    /// <param name="maxLength">maxLength</param>
    public static void ConfigureOrganizationCode<T>(this EntityTypeBuilder<T> b, int? maxLength = null)
        where T : class, IHasOrganizationCode
    {
        b.As<EntityTypeBuilder>().TryConfigureOrganizationCode(maxLength);
    }

    /// <summary>
    /// 配置组织Code
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    /// <param name="maxLength">maxLength</param>
    public static void TryConfigureOrganizationCode(this EntityTypeBuilder b, int? maxLength = null)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasOrganizationCode>())
        {
            b.Property(nameof(IHasOrganizationCode.OrganizationCode))
                .IsConcurrencyToken()
                .IsRequired()
                .HasColumnName(nameof(IHasOrganizationCode.OrganizationCode))
                .HasMaxLength(maxLength ?? OrganizationUnitConsts.MaxCodeLength)
                .HasComment("组织Code");
        }
    }

    /// <summary>
    /// 配置组织Id
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureOrganizationId<T>(this EntityTypeBuilder<T> b)
        where T : class, IHasOrganization
    {
        b.As<EntityTypeBuilder>().TryConfigureOrganizationId();
    }

    /// <summary>
    /// 配置组织Id
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureOrganizationId(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasOrganization>())
        {
            b.Property(nameof(IHasOrganization.OrganizationId))
                .IsConcurrencyToken()
                .IsRequired()
                .HasColumnName(nameof(IHasOrganization.OrganizationId))
                .HasComment("组织Id");
        }
    }

    /// <summary>
    /// 配置拼音首字母
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureNamePinyinFirstLetters<T>(this EntityTypeBuilder<T> b, int? maxLength = null)
        where T : class, IHasNamePinyin
    {
        b.As<EntityTypeBuilder>().TryConfigureNamePinyinFirstLetters(maxLength ?? PinyinFirstLettersConsts.MaxLength);
    }

    /// <summary>
    /// 配置拼音首字母
    /// </summary>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureNamePinyinFirstLetters(this EntityTypeBuilder b, int? maxLength = null)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasNamePinyin>())
        {
            b.Property(nameof(IHasNamePinyin.PinyinFirstLetters))
                .IsConcurrencyToken()
                .IsRequired()
                .HasMaxLength(maxLength ?? PinyinFirstLettersConsts.MaxLength)
                .HasColumnName(nameof(IHasNamePinyin.PinyinFirstLetters))
                .HasComment("拼音首字母");
        }
    }

    /// <summary>
    /// 配置拼音
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureNamePinyin<T>(this EntityTypeBuilder<T> b, int? maxLength = null)
        where T : class, IHasNamePinyin
    {
        b.As<EntityTypeBuilder>().TryConfigureNamePinyin(maxLength ?? PinyinConsts.MaxLength);
    }

    /// <summary>
    /// 配置拼音
    /// </summary>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureNamePinyin(this EntityTypeBuilder b, int? maxLength = null)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasNamePinyin>())
        {
            b.Property(nameof(IHasNamePinyin.Pinyin))
                .IsConcurrencyToken()
                .IsRequired()
                .HasMaxLength(maxLength ?? PinyinConsts.MaxLength)
                .HasColumnName(nameof(IHasNamePinyin.Pinyin))
                .HasComment("拼音");
        }
    }

    /// <summary>
    /// 配置描述
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureDescribe<T>(this EntityTypeBuilder<T> b, int? maxLength = null)
        where T : class, IMayHaveDescribe
    {
        b.As<EntityTypeBuilder>().TryConfigureDescribe(maxLength ?? DescribeConsts.MaxLength);
    }

    /// <summary>
    /// 配置描述
    /// </summary>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureDescribe(this EntityTypeBuilder b, int? maxLength = null)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveDescribe>())
        {
            b.Property(nameof(IMayHaveDescribe.Describe))
                .IsConcurrencyToken()
                .IsRequired(false)
                .HasMaxLength(maxLength ?? DescribeConsts.MaxLength)
                .HasColumnName(nameof(IMayHaveDescribe.Describe))
                .HasComment("描述");
        }
    }

    /// <summary>
    /// 配置名称
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureName<T>(this EntityTypeBuilder<T> b, int? maxLength = null)
        where T : class, IHasName
    {

        b.As<EntityTypeBuilder>().TryConfigureName(maxLength ?? NameConsts.MaxLength);
    }

    /// <summary>
    /// 配置名称
    /// </summary>
    /// <param name="maxLength">长度</param>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureName(this EntityTypeBuilder b, int? maxLength = null)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasName>())
        {
            b.Property(nameof(IHasName.Name))
                .IsConcurrencyToken()
                .IsRequired()
                .HasMaxLength(maxLength ?? NameConsts.MaxLength)
                .HasColumnName(nameof(IHasName.Name))
                .HasComment("名称");
        }
    }

    /// <summary>
    /// 配置创建人
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureCreatorName<T>(this EntityTypeBuilder<T> b)
        where T : class, IMayHaveCreatorName
    {
        b.As<EntityTypeBuilder>().TryConfigureCreatorName();
    }

    /// <summary>
    /// 配置创建人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureCreatorName(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveCreatorName>())
        {
            b.Property(nameof(IMayHaveCreatorName.CreatorName))
                .IsConcurrencyToken()
                .IsRequired(false)
                .HasMaxLength(CreatorNameConsts.MaxLength)
                .HasColumnName(nameof(IMayHaveCreatorName.CreatorName))
                .HasComment("创建人名称");
        }
    }

    /// <summary>
    /// 配置修改人
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureModificationName<T>(this EntityTypeBuilder<T> b)
        where T : class, IMayHaveModificationName
    {
        b.As<EntityTypeBuilder>().TryConfigureModificationName();
    }

    /// <summary>
    /// 配置修改人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureModificationName(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveModificationName>())
        {
            b.Property(nameof(IMayHaveModificationName.LastModificationName))
                .IsConcurrencyToken()
                .IsRequired(false)
                .HasMaxLength(LastModificationNameConsts.MaxLength)
                .HasColumnName(nameof(IMayHaveModificationName.LastModificationName))
                .HasComment("最后修改人名称");
        }
    }

    /// <summary>
    /// 配置删除人
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureDeletionName<T>(this EntityTypeBuilder<T> b)
        where T : class, IMayHaveDeletionName
    {
        b.As<EntityTypeBuilder>().TryConfigureDeletionName();
    }

    /// <summary>
    /// 配置删除人
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureDeletionName(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IMayHaveDeletionName>())
        {
            b.Property(nameof(IMayHaveDeletionName.DeletionName))
                .IsConcurrencyToken()
                .IsRequired(false)
                .HasMaxLength(DeletionNameConsts.MaxLength)
                .HasColumnName(nameof(IMayHaveDeletionName.DeletionName))
                .HasComment("删除人名称");
        }
    }

    /// <summary>
    /// 配置启用状态
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureEnable<T>(this EntityTypeBuilder<T> b)
        where T : class, IHasEnable
    {
        b.As<EntityTypeBuilder>().TryConfigureEnable();
    }

    /// <summary>
    /// 配置启用状态
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureEnable(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasEnable>())
        {
            b.Property(nameof(IHasEnable.Status))
                .IsConcurrencyToken()
                .IsRequired()
                .HasColumnName(nameof(IHasEnable.Status))
                .HasComment("启用状态");
        }
    }

    /// <summary>
    /// 配置排序
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureSort<T>(this EntityTypeBuilder<T> b)
        where T : class, IHasSort
    {
        b.As<EntityTypeBuilder>().TryConfigureSort();
    }

    /// <summary>
    /// 配置排序
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void TryConfigureSort(this EntityTypeBuilder b)
    {
        if (b.Metadata.ClrType.IsAssignableTo<IHasSort>())
        {
            b.Property(nameof(IHasSort.Sort))
                .IsConcurrencyToken()
                .IsRequired()
                .HasColumnName(nameof(IHasSort.Sort))
                .HasComment("排序字段");
        }
    }
}