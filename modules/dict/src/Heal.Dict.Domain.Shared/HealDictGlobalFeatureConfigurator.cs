using Volo.Abp.Threading;

namespace Heal.Dict.Domain.Shared;

/// <summary>
/// Configures global features of the Heal.Net.Domain.Shared module.
/// </summary>
public static class HealDictGlobalFeatureConfigurator
{
    /// <summary>
    /// Configures the global features of the Heal.Net.Domain.Shared module.
    /// </summary>
    private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// Configures the global features of the Heal.Net.Domain.Shared module.
    /// </summary>
    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
                /* You can configure (enable/disable) global features of the used modules here.
                 * Please refer to the documentation to learn more about the Global Features System:
                 * https://docs.abp.io/en/abp/latest/Global-Features
                 */
            });
    }
}