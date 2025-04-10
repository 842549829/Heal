using Heal.Domain.Shared.Constants;
using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Application.Contracts.Bases.Users.Dtos;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Heal.Net.Application.Contracts;

/// <summary>
/// Defines extension methods for DTOs in the Heal.Net.Application.Contracts module.
/// </summary>
public static class HealNetDtoExtensions
{
    /// <summary>
    /// Configures the Heal.Net.Application.Contracts module.
    /// </summary>
    private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// Configures the Heal.Net.Application.Contracts module.
    /// </summary>
    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            /* You can add extension properties to DTOs
             * defined in the depended modules.
             *
             * Example:
             *
             * ObjectExtensionManager.Instance
             *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
             *
             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Object-Extensions
             */

            // User
            Type[] userTypes = [
                typeof(IdentityUserDto),
                typeof(IdentityUserCreateDto),
                typeof(IdentityUserUpdateDto),
                typeof(ProfileDto),
                typeof(UpdateProfileDto) 
            ];
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(userTypes, IdentityUserExtensionConsts.OpenId)
                .AddOrUpdateProperty<string>([.. userTypes, typeof(UserAvatarUpdateDto)], IdentityUserExtensionConsts.Avatar)
                .AddOrUpdateProperty<int>(userTypes, IdentityUserExtensionConsts.Identity);

            // Role
            Type[] roleTypes = [
                typeof(IdentityRoleDto),
                typeof(IdentityRoleCreateDto),
                typeof(IdentityRoleUpdateDto),
                typeof(RoleCreateDto),
                typeof(RoleUpdateDto)
            ];
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<int>(roleTypes, IdentityRoleExtensionConsts.DataPermission)
                .AddOrUpdateProperty<string>(roleTypes, IdentityRoleExtensionConsts.CustomDataPermission);

            // Organization
            Type[] organizationTypes = [ typeof(OrganizationCreateDto),
                typeof(OrganizationDto),
                typeof(OrganizationTreeDto),
                typeof(OrganizationUpdateDto)];
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Director)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Level)
                .AddOrUpdateProperty<DateTime?>(organizationTypes, OrganizationUnitExtensionConsts.EstablishmentDate)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Phone)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Email)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.WebsiteUrl)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Address)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.PostalCode)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.ServiceHotline)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Introduction)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.TrafficGuide)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.ParkingInformation)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Describe)
                .AddOrUpdateProperty<decimal?>(organizationTypes, OrganizationUnitExtensionConsts.Latitude)
                .AddOrUpdateProperty<decimal?>(organizationTypes, OrganizationUnitExtensionConsts.Longitude)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.CoverImage)
                .AddOrUpdateProperty<DateTime?>(organizationTypes, OrganizationUnitExtensionConsts.OperatingHours)
                .AddOrUpdateProperty<bool?>(organizationTypes, OrganizationUnitExtensionConsts.IsEmergencyServices)
                .AddOrUpdateProperty<bool?>(organizationTypes, OrganizationUnitExtensionConsts.IsInsuranceAccepted)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConsts.Facilities);
        });
    }
}