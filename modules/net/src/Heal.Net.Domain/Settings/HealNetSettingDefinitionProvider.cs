using Volo.Abp.Settings;

namespace Heal.Net.Domain.Settings;

/// <summary>
/// Setting definitions provider for HealNet.
/// </summary>
public class HealNetSettingDefinitionProvider : SettingDefinitionProvider
{
    /// <summary>
    /// Defines the settings.
    /// </summary>
    /// <param name="context">context</param>
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HealSettings.MySetting1));
    }
}
