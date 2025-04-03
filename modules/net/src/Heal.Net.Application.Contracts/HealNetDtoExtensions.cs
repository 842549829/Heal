using Heal.Domain.Shared.Constants;
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

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(new[]
                    {
                        typeof(IdentityUserDto),
                        typeof(IdentityUserCreateDto),
                        typeof(IdentityUserUpdateDto),
                        typeof(ProfileDto),
                        typeof(UpdateProfileDto)
                    },
                    IdentityUserExtensionConsts.OpenId)
                .AddOrUpdateProperty<string>([
                        typeof(IdentityUserDto),
                        typeof(IdentityUserCreateDto),
                        typeof(IdentityUserUpdateDto),
                        typeof(ProfileDto),
                        typeof(UpdateProfileDto),
                        typeof(UserAvatarUpdateDto)
                    ],
                    IdentityUserExtensionConsts.Avatar);

            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<int>([
                        typeof(IdentityRoleDto),
                        typeof(IdentityRoleCreateDto),
                        typeof(IdentityRoleUpdateDto),
                        typeof(RoleCreateDto),
                        typeof(RoleUpdateDto)
                    ],
                    IdentityRoleExtensionConsts.DataPermission)
                .AddOrUpdateProperty<string>([
                        typeof(IdentityRoleDto),
                        typeof(IdentityRoleCreateDto),
                        typeof(IdentityRoleUpdateDto),
                        typeof(RoleCreateDto),
                        typeof(RoleUpdateDto)
                    ],
                    IdentityRoleExtensionConsts.CustomDataPermission);
        });
    }
}