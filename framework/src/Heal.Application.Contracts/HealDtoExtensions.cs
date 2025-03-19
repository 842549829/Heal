using Volo.Abp.Threading;

namespace Heal.Application.Contracts;

/// <summary>
/// This class can be used to configure DTOs.
/// </summary>
public static class HealDtoExtensions
{
    /// <summary>
    /// This method can be used to configure DTOs.
    /// </summary>
    private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// This method can be used to configure DTOs.
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
        });
    }
}