using Heal.Localization;
using Volo.Abp.Application.Services;

namespace Heal;

/* Inherit your application services from this class.
 */
public abstract class HealAppService : ApplicationService
{
    protected HealAppService()
    {
        LocalizationResource = typeof(HealResource);
    }
}
