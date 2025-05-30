using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Heal.Net.Application.Contracts.Permissions;

/* 图标地址
 * https://icon-sets.iconify.design/?query=organization
 * 需要复制 Iconify Icon 的 SVG 源代码
 * 比如<iconify-icon icon="eos-icons:organization" width="24" height="24"></iconify-icon> 这里的  icon="eos-icons:organization" 就是图标的标识
 */

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
            .WithProperty(PermissionDefinitionConstants.Title, "router.module");

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
            .WithProperty(PermissionDefinitionConstants.Title, "router.menu");

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
        #endregion

        #region Organizations
        var organizations = basicsGroup.AddPermission(HealNetPermissions.Organizations.Defaults, L("DisplayName:Organizations"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "/organizations")
            .WithProperty(PermissionDefinitionConstants.Component, "#")
            .WithProperty(PermissionDefinitionConstants.Redirect, "/organizations/organization")
            .WithProperty(PermissionDefinitionConstants.Name, "Organizations")
            .WithProperty(PermissionDefinitionConstants.Title, "router.organization")
            .WithProperty(PermissionDefinitionConstants.Icon, "eos-icons:organization")
            .WithProperty(PermissionDefinitionConstants.AlwaysShow, true);

        #region Organization
        var organizationPermission = organizations.AddChild(HealNetPermissions.Organizations.Organization.Default, L("DisplayName:Institutional"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "organization")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Organizations/Organization/Organization")
            .WithProperty(PermissionDefinitionConstants.Name, "Organization")
            .WithProperty(PermissionDefinitionConstants.Title, "router.organization");

        organizationPermission.AddChild(HealNetPermissions.Organizations.Organization.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        organizationPermission.AddChild(HealNetPermissions.Organizations.Organization.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        organizationPermission.AddChild(HealNetPermissions.Organizations.Organization.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Campuses
        var campusesPermission = organizations.AddChild(HealNetPermissions.Organizations.Campuses.Default, L("DisplayName:Campuses"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "campuses")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Organizations/Campuses/Campuses")
            .WithProperty(PermissionDefinitionConstants.Name, "Campuses")
            .WithProperty(PermissionDefinitionConstants.Title, "router.campuses");

        campusesPermission.AddChild(HealNetPermissions.Organizations.Campuses.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        campusesPermission.AddChild(HealNetPermissions.Organizations.Campuses.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        campusesPermission.AddChild(HealNetPermissions.Organizations.Campuses.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Department
        var departmentPermission = organizations.AddChild(HealNetPermissions.Organizations.Department.Default, L("DisplayName:Department"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "department")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Organizations/Department/Department")
            .WithProperty(PermissionDefinitionConstants.Name, "Department")
            .WithProperty(PermissionDefinitionConstants.Title, "router.department");

        departmentPermission.AddChild(HealNetPermissions.Organizations.Department.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        departmentPermission.AddChild(HealNetPermissions.Organizations.Department.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        departmentPermission.AddChild(HealNetPermissions.Organizations.Department.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion
        #endregion

        #region Personnel
        var personnels = basicsGroup.AddPermission(HealNetPermissions.Personnel.Defaults, L("DisplayName:Personnel"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "/personnel")
            .WithProperty(PermissionDefinitionConstants.Component, "#")
            .WithProperty(PermissionDefinitionConstants.Redirect, "/organizations/personnel")
            .WithProperty(PermissionDefinitionConstants.Name, "Personnel")
            .WithProperty(PermissionDefinitionConstants.Title, "router.personnel")
            .WithProperty(PermissionDefinitionConstants.Icon, "rivet-icons:user-solid")
            .WithProperty(PermissionDefinitionConstants.AlwaysShow, true);

        #region Doctors
        var doctorPermission = personnels.AddChild(HealNetPermissions.Personnel.Doctors.Default, L("DisplayName:Doctor"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "doctor")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Personnel/Doctor/Doctor")
            .WithProperty(PermissionDefinitionConstants.Name, "Doctor")
            .WithProperty(PermissionDefinitionConstants.Title, "router.doctor");

        doctorPermission.AddChild(HealNetPermissions.Personnel.Doctors.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        doctorPermission.AddChild(HealNetPermissions.Personnel.Doctors.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        doctorPermission.AddChild(HealNetPermissions.Personnel.Doctors.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Patients
        var patientPermission = personnels.AddChild(HealNetPermissions.Personnel.Patients.Default, L("DisplayName:Patient"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "patient")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Personnel/Patient/Patient")
            .WithProperty(PermissionDefinitionConstants.Name, "Patient")
            .WithProperty(PermissionDefinitionConstants.Title, "router.patient");

        patientPermission.AddChild(HealNetPermissions.Personnel.Patients.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        patientPermission.AddChild(HealNetPermissions.Personnel.Patients.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        patientPermission.AddChild(HealNetPermissions.Personnel.Patients.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion
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
