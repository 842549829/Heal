using Heal.Domain.Shared.Constants;
using Heal.Net.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/// <summary>
/// EntityFrameworkCore extension mappings for Heal.Net.
/// </summary>
public static class HealNetEfCoreEntityExtensionMappings
{
    /// <summary>
    /// Configures the entity extension mappings for Heal.Net.
    /// </summary>
    private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// Configures the entity extension mappings for Heal.Net.
    /// </summary>
    public static void Configure()
    {
        HealNetGlobalFeatureConfigurator.Configure();
        HealNetModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE HealModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */

            // 用户扩展信息
            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, string>(
                    IdentityUserExtensionConsts.OpenId,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(IdentityUserExtensionConsts.MaxOpenIdLength);
                        propertyBuilder.HasDefaultValue(string.Empty);
                        propertyBuilder.IsRequired();
                        propertyBuilder.HasComment("第三方登录唯一标识");
                        propertyBuilder.HasColumnName(IdentityUserExtensionConsts.OpenId);
                    }
                ).MapEfCoreProperty<IdentityUser, string>(IdentityUserExtensionConsts.Avatar,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(IdentityUserExtensionConsts.MaxAvatarLength);
                        propertyBuilder.HasDefaultValue(string.Empty);
                        propertyBuilder.IsRequired();
                        propertyBuilder.HasComment("头像");
                        propertyBuilder.HasColumnName(IdentityUserExtensionConsts.Avatar);
                    })
                .MapEfCoreProperty<IdentityUser, int>(IdentityUserExtensionConsts.Identity,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(1);
                        propertyBuilder.IsRequired();
                        propertyBuilder.HasComment("身份标识");
                        propertyBuilder.HasColumnName(IdentityUserExtensionConsts.Identity);
                    });

            // 角色扩展信息
            ObjectExtensionManager
                .Instance
                .MapEfCoreProperty<IdentityRole, int>(IdentityRoleExtensionConsts.DataPermission,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(0);
                        propertyBuilder.IsRequired();
                        propertyBuilder.HasComment("数据权限");
                        propertyBuilder.HasColumnName(IdentityRoleExtensionConsts.DataPermission);
                    })
                .MapEfCoreProperty<IdentityRole, string>(IdentityRoleExtensionConsts.CustomDataPermission,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(IdentityRoleExtensionConsts.MaxCustomDataPermissionLength);
                        propertyBuilder.HasDefaultValue(string.Empty);
                        propertyBuilder.IsRequired();
                        propertyBuilder.HasComment("自定义数据权限");
                        propertyBuilder.HasColumnName(IdentityRoleExtensionConsts.CustomDataPermission);
                    });

            // 机构扩展信息
            ObjectExtensionManager
                .Instance
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Director,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("院长");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxDirectorLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Director);
                    })
                .MapEfCoreProperty<OrganizationUnit, int?>(OrganizationUnitExtensionConsts.Level,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院等级");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Level);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Phone,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("联系电话");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxPhoneLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Phone);
                    })
                .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConsts.EstablishmentDate,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("成立时间");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.EstablishmentDate);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Email,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("邮箱");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxEmailLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Email);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.WebsiteUrl,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("官方网站");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxWebsiteUrlLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.WebsiteUrl);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Address,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("地址");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxAddressLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Address);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.PostalCode,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("邮政编码");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxPostalCodeLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.PostalCode);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.ServiceHotline,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("服务热线");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxServiceHotlineLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.ServiceHotline);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Introduction,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院简介");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxIntroductionLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Introduction);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.TrafficGuide,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("交通指南");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxTrafficGuideLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.TrafficGuide);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.ParkingInformation,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("停车信息");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxParkingInformationLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.ParkingInformation);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Describe,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("备注描述");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxDescribeLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Describe);
                    })
                .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConsts.Latitude,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("纬度");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Latitude);
                    })
                .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConsts.Longitude,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("经度");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Longitude);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.CoverImage,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("封面图片");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxCoverImageLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.CoverImage);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Facilities,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院设施");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxFacilitiesLength);
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.Facilities);
                    })
                .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConsts.OperatingHours,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("营业时间");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.OperatingHours);
                    })
                .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConsts.IsEmergencyServices,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("是否提供急诊服务");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.IsEmergencyServices);
                    })
                .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConsts.IsInsuranceAccepted,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("是否接受医保");
                        propertyBuilder.HasColumnName(OrganizationUnitExtensionConsts.IsInsuranceAccepted);
                    });
        });
    }
}
