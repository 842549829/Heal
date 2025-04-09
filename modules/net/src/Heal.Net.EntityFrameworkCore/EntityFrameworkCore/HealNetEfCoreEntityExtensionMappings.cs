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
                    }
                ).MapEfCoreProperty<IdentityUser, string>(IdentityUserExtensionConsts.Avatar,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(IdentityUserExtensionConsts.MaxAvatarLength);
                        propertyBuilder.HasDefaultValue(string.Empty);
                        propertyBuilder.IsRequired();
                    })
                .MapEfCoreProperty<IdentityUser, int>(IdentityUserExtensionConsts.Identity,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(1);
                        propertyBuilder.IsRequired();
                    });

            // 角色扩展信息
            ObjectExtensionManager
                .Instance
                .MapEfCoreProperty<IdentityRole, int>(IdentityRoleExtensionConsts.DataPermission,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasDefaultValue(0);
                        propertyBuilder.IsRequired();
                    })
                .MapEfCoreProperty<IdentityRole, string>(IdentityRoleExtensionConsts.CustomDataPermission,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.HasMaxLength(IdentityRoleExtensionConsts.MaxCustomDataPermissionLength);
                        propertyBuilder.HasDefaultValue(string.Empty);
                        propertyBuilder.IsRequired();
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
                    })
                .MapEfCoreProperty<OrganizationUnit, int?>(OrganizationUnitExtensionConsts.Level,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院等级");
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Phone,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("联系电话");
                    })
                .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConsts.EstablishmentDate,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("成立时间");
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Email,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("邮箱");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxEmailLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.WebsiteUrl,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("官方网站");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxWebsiteUrlLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Address,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("地址");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxAddressLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.PostalCode,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("邮政编码");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxPostalCodeLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.ServiceHotline,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("服务热线");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxServiceHotlineLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Introduction,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院简介");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxIntroductionLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.TrafficGuide,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("交通指南");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxTrafficGuideLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.ParkingInformation,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("停车信息");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxParkingInformationLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Describe,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("备注描述");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxDescribeLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConsts.Latitude,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("纬度");
                    })
                .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConsts.Longitude,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("经度");
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.CoverImage,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("封面图片");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxCoverImageLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConsts.Facilities,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("医院设施");
                        propertyBuilder.HasMaxLength(OrganizationUnitExtensionConsts.MaxFacilitiesLength);
                    })
                .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConsts.OperatingHours,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("营业时间");
                    })
                .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConsts.IsEmergencyServices,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("是否提供急诊服务");
                    })
                .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConsts.IsInsuranceAccepted,
                    (_, propertyBuilder) =>
                    {
                        propertyBuilder.IsRequired(false);
                        propertyBuilder.HasComment("是否接受医保");
                    });
        });
    }
}
