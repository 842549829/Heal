using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Heal.Dict.Application.Contracts.Permissions;

/// <summary>
/// 权限定义提供者
/// </summary>
public class HealDictPermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <summary>
    /// 定义权限
    /// </summary>
    /// <param name="context">context</param>
    public override void Define(IPermissionDefinitionContext context)
    {
        #region Dict
        var basicsGroup = context.AddGroup(HealDictPermissions.GroupName, L("F:Dict"));
        basicsGroup[PermissionDefinitionConstants.Type] = PermissionType.Module;
        basicsGroup[PermissionDefinitionConstants.Hidden] = false;
        basicsGroup[PermissionDefinitionConstants.Tag] = ModuleTag.NormalSystem;
        #endregion

        #region Icd
        var icds = basicsGroup.AddPermission(HealDictPermissions.Icd.Defaults, L("DisplayName:Icd"))
          .WithProviders(RolePermissionValueProvider.ProviderName)
          .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
          .WithProperty(PermissionDefinitionConstants.Path, "/icd")
          .WithProperty(PermissionDefinitionConstants.Component, "#")
          .WithProperty(PermissionDefinitionConstants.Redirect, "/icd/icd10")
          .WithProperty(PermissionDefinitionConstants.Name, "Icd")
          .WithProperty(PermissionDefinitionConstants.Title, "router.icd")
          .WithProperty(PermissionDefinitionConstants.Icon, "healthicons:icd-outline")
          .WithProperty(PermissionDefinitionConstants.AlwaysShow, true);

        #region Icd10
        var icds10Permission = icds.AddChild(HealDictPermissions.Icd.Icd10.Default, L("DisplayName:Icd10"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
            .WithProperty(PermissionDefinitionConstants.Path, "icd10")
            .WithProperty(PermissionDefinitionConstants.Component, "views/Dict/Icd/Icd10/Icd10")
            .WithProperty(PermissionDefinitionConstants.Name, "Icd10")
            .WithProperty(PermissionDefinitionConstants.Title, "router.icd10");

        icds10Permission.AddChild(HealDictPermissions.Icd.Icd10.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        icds10Permission.AddChild(HealDictPermissions.Icd.Icd10.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        icds10Permission.AddChild(HealDictPermissions.Icd.Icd10.Delete, L("DisplayName:Delete"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "delete");
        #endregion

        #region Icd9
        var icd9Permission = icds.AddChild(HealDictPermissions.Icd.Icd9.Default, L("DisplayName:Icd9"))
           .WithProviders(RolePermissionValueProvider.ProviderName)
           .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Menu)
           .WithProperty(PermissionDefinitionConstants.Path, "icd9")
           .WithProperty(PermissionDefinitionConstants.Component, "views/Dict/Icd/Icd9/Icd9")
           .WithProperty(PermissionDefinitionConstants.Name, "Icd9")
           .WithProperty(PermissionDefinitionConstants.Title, "router.icd9");

        icd9Permission.AddChild(HealDictPermissions.Icd.Icd9.Create, L("DisplayName:Create"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "create");
        icd9Permission.AddChild(HealDictPermissions.Icd.Icd9.Update, L("DisplayName:Edit"))
            .WithProviders(RolePermissionValueProvider.ProviderName)
            .WithProperty(PermissionDefinitionConstants.Type, PermissionType.Button)
            .WithProperty(PermissionDefinitionConstants.Path, "edit");
        icd9Permission.AddChild(HealDictPermissions.Icd.Icd9.Delete, L("DisplayName:Delete"))
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