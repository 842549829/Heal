using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.Identity;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// EntityTypeBuilder扩展
/// </summary>
public static class HealEntityTypeBuilderExtensions
{
    /// <summary>
    /// 配置实体
    /// </summary>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureByConventionByHealthcareAuditedAggregateRoot(this EntityTypeBuilder b)
    {
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
    public static void ConfigureByConventionByFullHealthcareAuditedAggregateRoot(this EntityTypeBuilder b)
    {
        b.ConfigureByConventionByHealthcareAuditedAggregateRoot();
        b.TryConfigureOrganizationId();
        b.TryConfigureOrganizationCode();
        b.TryConfigureParentId();
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
                .HasColumnName(nameof(IMayHaveParentId.ParentId));
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
                .HasMaxLength(maxLength ?? OrganizationUnitConsts.MaxCodeLength);
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
                .HasColumnName(nameof(IHasOrganization.OrganizationId));
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
                .HasColumnName(nameof(IHasNamePinyin.PinyinFirstLetters));
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
                .HasColumnName(nameof(IHasNamePinyin.Pinyin));
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
                .HasColumnName(nameof(IMayHaveDescribe.Describe));
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
                .HasColumnName(nameof(IHasName.Name));
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
                .HasColumnName(nameof(IMayHaveCreatorName.CreatorName));
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
                .HasColumnName(nameof(IMayHaveModificationName.LastModificationName));
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
                .HasColumnName(nameof(IMayHaveDeletionName.DeletionName));
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
                .HasColumnName(nameof(IHasEnable.Status));
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
                .HasColumnName(nameof(IHasSort.Sort));
        }
    }
}