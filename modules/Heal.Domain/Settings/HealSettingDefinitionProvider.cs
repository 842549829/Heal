using Volo.Abp.Settings;

namespace Heal.Settings;

public class HealSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HealSettings.MySetting1));
    }
}
