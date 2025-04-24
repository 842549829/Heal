using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// 模块应用服务
/// </summary>
/// <param name="permissionGroupDefinitionRecordRepository">模块仓储</param>
public class ModuleAppService(IRepository<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecordRepository) : HealNetAppService, IModuleAppService
{
    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns>Task</returns>
    public async Task CeateAsync(ModuleCreateDto input)
    {
        if (await permissionGroupDefinitionRecordRepository.AnyAsync(d => d.Name == input.Name))
        {
            throw new UserFriendlyException(L[LocalizedTextsConsts.ModuleAlreadyExists]);
        }
        var entity = new PermissionGroupDefinitionRecord(GuidGenerator.Create(), input.Name, input.DislayName);
        SetProperty(entity, input);
        await permissionGroupDefinitionRecordRepository.InsertAsync(entity);
        await CurrentUnitOfWork?.SaveChangesAsync()!;
    }

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    public async Task UpdateAsync(Guid id, ModuleUpdateDto input)
    {
        var entity = await permissionGroupDefinitionRecordRepository.GetAsync(d => d.Id == id);
        entity.DisplayName = input.DislayName;
        SetProperty(entity, input);
         await permissionGroupDefinitionRecordRepository.UpdateAsync(entity);
        await CurrentUnitOfWork?.SaveChangesAsync()!;
    }

    /// <summary>
    /// 设置属性
    /// </summary>
    /// <param name="entity">entity</param>
    /// <param name="input">input</param>
    private static void SetProperty(PermissionGroupDefinitionRecord entity, IModuleCreateOrUpdateDto input)
    {
        entity.SetProperty(PermissionDefinitionConsts.Path, input.Path);
        entity.SetProperty(PermissionDefinitionConsts.Component, input.Component);
        entity.SetProperty(PermissionDefinitionConsts.Type, PermissionType.Module);
        entity.SetProperty(PermissionDefinitionConsts.Redirect, input.Redirect);
        entity.SetProperty(PermissionDefinitionConsts.Alias, input.Alias);
        entity.SetProperty(PermissionDefinitionConsts.Hidden, input.Hidden);
        entity.SetProperty(PermissionDefinitionConsts.AlwaysShow, input.AlwaysShow);
        entity.SetProperty(PermissionDefinitionConsts.Icon, input.Icon);
        entity.SetProperty(PermissionDefinitionConsts.NoCache, input.NoCache);
        entity.SetProperty(PermissionDefinitionConsts.Breadcrumb, input.Breadcrumb);
        entity.SetProperty(PermissionDefinitionConsts.Affix, input.Affix);
        entity.SetProperty(PermissionDefinitionConsts.ActiveMenu, input.ActiveMenu);
        entity.SetProperty(PermissionDefinitionConsts.NoTagsView, input.NoTagsView);
        entity.SetProperty(PermissionDefinitionConsts.CanTo, input.CanTo);
        entity.SetProperty(PermissionDefinitionConsts.Title, input.DislayName);
        entity.SetProperty(PermissionDefinitionConsts.Tag, input.Tag);
    }
}