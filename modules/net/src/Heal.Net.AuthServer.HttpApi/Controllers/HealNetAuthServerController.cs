using Heal.Net.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Heal.Net.AuthServer.HttpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HealNetAuthServerController : AbpControllerBase
{
    protected HealNetAuthServerController()
    {
        LocalizationResource = typeof(HealResource);
    }
}
