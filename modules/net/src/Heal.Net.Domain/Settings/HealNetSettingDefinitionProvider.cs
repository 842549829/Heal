﻿using Volo.Abp.Settings;

namespace Heal.Net.Domain.Settings;

public class HealNetSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HealSettings.MySetting1));
    }
}
