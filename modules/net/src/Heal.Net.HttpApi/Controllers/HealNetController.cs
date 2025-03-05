using Heal.Net.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HealNetController : AbpControllerBase
{
    protected HealNetController()
    {
        LocalizationResource = typeof(HealResource);
    }
}
