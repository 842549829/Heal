using Heal.Net.Domain.Shared.Localization;
using Volo.Abp.Application.Services;

namespace Heal.Net.Application;

/* Inherit your application services from this class.
 */
public abstract class HealNetAppService : ApplicationService
{
    protected HealNetAppService()
    {
        LocalizationResource = typeof(HealNetResource);
    }
}
