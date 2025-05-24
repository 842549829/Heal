using Heal.Domain.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore
{
    /// <summary>
    /// EntityFrameworkCore extension mappings for Heal.Net.
    /// </summary>
    public static class HealCoretEfCoreEntityExtensionMappings
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
                        IdentityUserExtensionConstants.OpenId,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(IdentityUserExtensionConstants.MaxOpenIdLength);
                            propertyBuilder.HasDefaultValue(string.Empty);
                            propertyBuilder.IsRequired();
                            propertyBuilder.HasComment("第三方登录唯一标识");
                            propertyBuilder.HasColumnName(IdentityUserExtensionConstants.OpenId);
                        }
                    ).MapEfCoreProperty<IdentityUser, string>(IdentityUserExtensionConstants.Avatar,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(IdentityUserExtensionConstants.MaxAvatarLength);
                            propertyBuilder.HasDefaultValue(string.Empty);
                            propertyBuilder.IsRequired();
                            propertyBuilder.HasComment("头像");
                            propertyBuilder.HasColumnName(IdentityUserExtensionConstants.Avatar);
                        })
                    .MapEfCoreProperty<IdentityUser, int>(IdentityUserExtensionConstants.Identity,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.HasDefaultValue(1);
                            propertyBuilder.IsRequired();
                            propertyBuilder.HasComment("身份标识");
                            propertyBuilder.HasColumnName(IdentityUserExtensionConstants.Identity);
                        });

                // 角色扩展信息
                ObjectExtensionManager
                    .Instance
                    .MapEfCoreProperty<IdentityRole, int>(IdentityRoleExtensionConstants.DataPermission,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.HasDefaultValue(0);
                            propertyBuilder.IsRequired();
                            propertyBuilder.HasComment("数据权限");
                            propertyBuilder.HasColumnName(IdentityRoleExtensionConstants.DataPermission);
                        })
                    .MapEfCoreProperty<IdentityRole, string>(IdentityRoleExtensionConstants.CustomDataPermission,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.HasMaxLength(IdentityRoleExtensionConstants.MaxCustomDataPermissionLength);
                            propertyBuilder.HasDefaultValue(string.Empty);
                            propertyBuilder.IsRequired();
                            propertyBuilder.HasComment("自定义数据权限");
                            propertyBuilder.HasColumnName(IdentityRoleExtensionConstants.CustomDataPermission);
                        });

                // 机构扩展信息
                ObjectExtensionManager
                    .Instance
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Director,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("院长");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxDirectorLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Director);
                        })
                    .MapEfCoreProperty<OrganizationUnit, int?>(OrganizationUnitExtensionConstants.Level,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("医院等级");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Level);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Phone,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("联系电话");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxPhoneLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Phone);
                        })
                    .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConstants.EstablishmentDate,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("成立时间");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.EstablishmentDate);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Email,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("邮箱");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxEmailLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Email);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.WebsiteUrl,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("官方网站");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxWebsiteUrlLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.WebsiteUrl);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Address,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("地址");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxAddressLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Address);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.PostalCode,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("邮政编码");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxPostalCodeLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.PostalCode);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.ServiceHotline,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("服务热线");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxServiceHotlineLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.ServiceHotline);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Introduction,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("医院简介");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxIntroductionLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Introduction);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.TrafficGuide,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("交通指南");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxTrafficGuideLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.TrafficGuide);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.ParkingInformation,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("停车信息");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxParkingInformationLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.ParkingInformation);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Describe,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("备注描述");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxDescribeLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Describe);
                        })
                    .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConstants.Latitude,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("纬度");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Latitude);
                        })
                    .MapEfCoreProperty<OrganizationUnit, decimal?>(OrganizationUnitExtensionConstants.Longitude,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("经度");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Longitude);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.CoverImage,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("封面图片");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxCoverImageLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.CoverImage);
                        })
                    .MapEfCoreProperty<OrganizationUnit, string?>(OrganizationUnitExtensionConstants.Facilities,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("医院设施");
                            propertyBuilder.HasMaxLength(OrganizationUnitExtensionConstants.MaxFacilitiesLength);
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.Facilities);
                        })
                    .MapEfCoreProperty<OrganizationUnit, DateTime?>(OrganizationUnitExtensionConstants.OperatingHours,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("营业时间");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.OperatingHours);
                        })
                    .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConstants.IsEmergencyServices,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("是否提供急诊服务");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.IsEmergencyServices);
                        })
                    .MapEfCoreProperty<OrganizationUnit, bool?>(OrganizationUnitExtensionConstants.IsInsuranceAccepted,
                        (_, propertyBuilder) =>
                        {
                            propertyBuilder.IsRequired(false);
                            propertyBuilder.HasComment("是否接受医保");
                            propertyBuilder.HasColumnName(OrganizationUnitExtensionConstants.IsInsuranceAccepted);
                        });
            });
        }
    }
}
