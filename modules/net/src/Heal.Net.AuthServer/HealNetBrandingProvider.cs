using Heal.Net.Domain.Shared.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Heal.Net.AuthServer;

[Dependency(ReplaceServices = true)]
public class HealNetBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HealResource> _localizer;

    public HealNetBrandingProvider(IStringLocalizer<HealResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
