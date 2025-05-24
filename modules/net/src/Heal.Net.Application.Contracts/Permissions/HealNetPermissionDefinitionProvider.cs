using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Heal.Net.Application.Contracts.Permissions;

/// <summary>
/// 权限定义
/// </summary>
public class HealNetPermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <summary>
    /// 定义权限
    /// </summary>
    /// <param name="context"></param>
    public override void Define(IPermissionDefinitionContext context)
    {
        #region Net
        var basicsGroup = context.AddGroup(HealNetPermissions.GroupName, L("F:Net"));
        basicsGroup[PermissionDefinitionConstants.Type] = PermissionType.Module;
        basicsGroup[PermissionDefinitionConstants.Hidden] = false;
        basicsGroup[PermissionDefinitionConstants.Tag] = ModuleTag.NormalSystem;
        #endregion

        #region Authorization
        var authorizations = basicsGroup.AddPermission(HealNetPermissions.Authorizations.Defaults, L("DisplayName:Authorization"))
          .WithProviders(RolePermissionValueProvider.ProviderName)
          .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
          .WithProperty(PermissionDefinitionConstants.Path, "/authorization")
          .WithProperty(PermissionDefinitionConstants.Component, "#")
          .WithProperty(PermissionDefinitionConstants.Redirect, "/authorization/user")
          .WithProperty(PermissionDefinitionConstants.Name, "Authorization")
          .WithProperty(PermissionDefinitionConstants.Title, "router.authorization")
          .WithProperty(PermissionDefinitionConstants.Icon, "vi-eos-icons:role-binding")
          .WithProperty(PermissionDefinitionConstants.AlwaysShow, true);
        #endregion

        #region Role
        var rolesPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Roles.Default, L("DisplayName:RoleManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "role")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Authorization/Role/Role")
            .WithProperty(PermissionDefinitionConstants.Name, "Role")
            .WithProperty(PermissionDefinitionConstants.Title, "router.role");

        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region User
        var usersPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Users.Default, L("DisplayName:UserManagement"))
           .WithProviders(RolePermissionValueProvider.ProviderName)
           .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
           .WithProperty(PermissionDefinitionConstants.Path, "user")
           .WithProperty(PermissionDefinitionConstants.Component, "views/Authorization/User/User")
           .WithProperty(PermissionDefinitionConstants.Name, "User")
           .WithProperty(PermissionDefinitionConstants.Title, "router.user");

        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Module
        var modulesPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Modules.Default, L("DisplayName:ModuleManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "module")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Authorization/Module/Module")
            .WithProperty(PermissionDefinitionConstants.Name, "Module")
            .WithProperty(PermissionDefinitionConstants.Title, "module.module");

        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Menu
        var menusPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Menus.Default, L("DisplayName:MenuManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "menu")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Authorization/Menu/Menu")
            .WithProperty(PermissionDefinitionConstants.Name, "Menu")
            .WithProperty(PermissionDefinitionConstants.Title, "menu.menu");

        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion
    }

    /// <summary>
    /// 获取本地化字符串
    /// </summary>
    /// <param name="name">名称</param>
    /// <returns>本地化字符串</returns>
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HealResource>(name);
    }
}
