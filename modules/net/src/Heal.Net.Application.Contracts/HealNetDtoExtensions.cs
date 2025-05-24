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
                .AddOrUpdateProperty<string>(userTypes, IdentityUserExtensionConstants.OpenId)
                .AddOrUpdateProperty<string>([.. userTypes, typeof(UserAvatarUpdateDto)], IdentityUserExtensionConstants.Avatar)
                .AddOrUpdateProperty<int>(userTypes, IdentityUserExtensionConstants.Identity);

            // Role
            Type[] roleTypes = [
                typeof(IdentityRoleDto),
                typeof(IdentityRoleCreateDto),
                typeof(IdentityRoleUpdateDto),
                typeof(RoleCreateDto),
                typeof(RoleUpdateDto)
            ];
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<int>(roleTypes, IdentityRoleExtensionConstants.DataPermission)
                .AddOrUpdateProperty<string>(roleTypes, IdentityRoleExtensionConstants.CustomDataPermission);

            // Organization
            Type[] organizationTypes = [ typeof(OrganizationCreateDto),
                typeof(OrganizationDto),
                typeof(OrganizationTreeDto),
                typeof(OrganizationUpdateDto)];
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Director)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Level)
                .AddOrUpdateProperty<DateTime?>(organizationTypes, OrganizationUnitExtensionConstants.EstablishmentDate)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Phone)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Email)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.WebsiteUrl)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Address)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.PostalCode)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.ServiceHotline)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Introduction)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.TrafficGuide)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.ParkingInformation)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Describe)
                .AddOrUpdateProperty<decimal?>(organizationTypes, OrganizationUnitExtensionConstants.Latitude)
                .AddOrUpdateProperty<decimal?>(organizationTypes, OrganizationUnitExtensionConstants.Longitude)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.CoverImage)
                .AddOrUpdateProperty<DateTime?>(organizationTypes, OrganizationUnitExtensionConstants.OperatingHours)
                .AddOrUpdateProperty<bool?>(organizationTypes, OrganizationUnitExtensionConstants.IsEmergencyServices)
                .AddOrUpdateProperty<bool?>(organizationTypes, OrganizationUnitExtensionConstants.IsInsuranceAccepted)
                .AddOrUpdateProperty<string?>(organizationTypes, OrganizationUnitExtensionConstants.Facilities);
        });
    }
}