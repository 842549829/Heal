using Heal.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Heal.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HealController : AbpControllerBase
{
    protected HealController()
    {
        LocalizationResource = typeof(HealResource);
    }
}
