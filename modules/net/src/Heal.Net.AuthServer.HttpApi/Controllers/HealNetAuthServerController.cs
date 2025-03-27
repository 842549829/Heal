using Heal.Domain.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Heal.Net.AuthServer.HttpApi.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HealNetAuthServerController : AbpControllerBase
{
    /// <summary>
    /// 构造函数
    /// </summary>
    protected HealNetAuthServerController()
    {
        LocalizationResource = typeof(HealResource);
    }
}
