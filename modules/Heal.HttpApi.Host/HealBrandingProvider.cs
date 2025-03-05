using Microsoft.Extensions.Localization;
using Heal.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Heal;

[Dependency(ReplaceServices = true)]
public class HealBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HealResource> _localizer;

    public HealBrandingProvider(IStringLocalizer<HealResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
