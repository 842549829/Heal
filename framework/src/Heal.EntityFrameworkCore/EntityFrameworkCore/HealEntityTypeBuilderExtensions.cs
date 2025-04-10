using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }

    /// <summary>
    /// 配置组织Id
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    /// <param name="b">EntityTypeBuilder</param>
    public static void ConfigureOrganizationId<T>(this EntityTypeBuilder<T> b)
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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
        where T : class, IMayHaveCreatorName
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