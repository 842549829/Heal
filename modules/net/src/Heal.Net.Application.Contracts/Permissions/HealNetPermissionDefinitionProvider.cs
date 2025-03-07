using Heal.Net.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Heal.Net.Application.Contracts.Permissions;

public class HealNetPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HealNetPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(HealPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HealNetResource>(name);
    }
}
