using Volo.Abp.Threading;

namespace Heal.Domain.Shared;

/// <summary>
/// 全局功能配置
/// </summary>
public class HealGlobalFeatureConfigurator
{
    /// <summary>
    /// 保证全局功能配置只执行一次
    /// </summary>
    private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// 全局功能配置
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