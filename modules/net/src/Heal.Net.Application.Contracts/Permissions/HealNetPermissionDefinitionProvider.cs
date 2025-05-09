﻿using Heal.Domain.Shared.Constants;
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
        basicsGroup[PermissionDefinitionConsts.Type] = PermissionType.Module;
        basicsGroup[PermissionDefinitionConsts.Hidden] = false;
        basicsGroup[PermissionDefinitionConsts.Tag] = ModuleTag.NormalSystem;
        #endregion

        #region Authorization
        var authorizations = basicsGroup.AddPermission(HealNetPermissions.Authorizations.Defaults, L("DisplayName:Authorization"))
          .WithProviders(RolePermissionValueProvider.ProviderName)
          .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Menu)
          .WithProperty(PermissionDefinitionConsts.Path, "/authorization")
          .WithProperty(PermissionDefinitionConsts.Component, "#")
          .WithProperty(PermissionDefinitionConsts.Redirect, "/authorization/user")
          .WithProperty(PermissionDefinitionConsts.Name, "Authorization")
          .WithProperty(PermissionDefinitionConsts.Title, "router.authorization")
          .WithProperty(PermissionDefinitionConsts.Icon, "vi-eos-icons:role-binding")
          .WithProperty(PermissionDefinitionConsts.AlwaysShow, true);
        #endregion

        #region Role
        var rolesPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Roles.Default, L("DisplayName:RoleManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConsts.Path, "role")
            .WithProperty(PermissionDefinitionConsts.Component, "views/Authorization/Role/Role")
            .WithProperty(PermissionDefinitionConsts.Name, "Role")
            .WithProperty(PermissionDefinitionConsts.Title, "router.role");

        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "create");
        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "edit");
        rolesPermission.AddChild(HealNetPermissions.Authorizations.Roles.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "delete");
        #endregion

        #region User
        var usersPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Users.Default, L("DisplayName:UserManagement"))
           .WithProviders(RolePermissionValueProvider.ProviderName)
           .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Menu)
           .WithProperty(PermissionDefinitionConsts.Path, "user")
           .WithProperty(PermissionDefinitionConsts.Component, "views/Authorization/User/User")
           .WithProperty(PermissionDefinitionConsts.Name, "User")
           .WithProperty(PermissionDefinitionConsts.Title, "router.user");

        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "create");
        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "edit");
        usersPermission.AddChild(HealNetPermissions.Authorizations.Users.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "delete");
        #endregion

        #region Module
        var modulesPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Modules.Default, L("DisplayName:ModuleManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConsts.Path, "module")
            .WithProperty(PermissionDefinitionConsts.Component, "views/Authorization/Module/Module")
            .WithProperty(PermissionDefinitionConsts.Name, "Module")
            .WithProperty(PermissionDefinitionConsts.Title, "module.module");

        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "create");
        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "edit");
        modulesPermission.AddChild(HealNetPermissions.Authorizations.Modules.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "delete");
        #endregion

        #region Menu
        var menusPermission = authorizations.AddChild(HealNetPermissions.Authorizations.Menus.Default, L("DisplayName:MenuManagement"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConsts.Path, "menu")
            .WithProperty(PermissionDefinitionConsts.Component, "views/Authorization/Menu/Menu")
            .WithProperty(PermissionDefinitionConsts.Name, "Menu")
            .WithProperty(PermissionDefinitionConsts.Title, "menu.menu");

        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "create");
        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "edit");
        menusPermission.AddChild(HealNetPermissions.Authorizations.Menus.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConsts.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConsts.Path, "delete");
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
