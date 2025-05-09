﻿using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Domain.Bases.Permissions.Repositories;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// 模块应用服务
/// </summary>
/// <param name="permissionGroupDefinitionRecordRepository">模块仓储</param>
/// <param name="moduleRepository">模块仓储</param>
public class ModuleAppService(IRepository<PermissionGroupDefinitionRecord> permissionGroupDefinitionRecordRepository,
    IModuleRepository moduleRepository) : HealNetAppService, IModuleAppService
{
    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public async Task CeateAsync(ModuleCreateDto input, CancellationToken cancellationToken = default)
    {
        if (await permissionGroupDefinitionRecordRepository.AnyAsync(d => d.Name == input.Name, cancellationToken: cancellationToken))
        {
            throw new UserFriendlyException(L[LocalizedTextsConsts.ModuleAlreadyExists]);
        }
        var entity = new PermissionGroupDefinitionRecord(GuidGenerator.Create(), input.Name, input.DisplayName);
        SetProperty(entity, input);
        await permissionGroupDefinitionRecordRepository.InsertAsync(entity, cancellationToken: cancellationToken);
        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;
    }

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public async Task UpdateAsync(Guid id, ModuleUpdateDto input, CancellationToken cancellationToken = default)
    {
        var entity = await permissionGroupDefinitionRecordRepository.GetAsync(d => d.Id == id, cancellationToken: cancellationToken);
        entity.DisplayName = input.DisplayName;
        SetProperty(entity, input);
        await permissionGroupDefinitionRecordRepository.UpdateAsync(entity, cancellationToken: cancellationToken);
        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;
    }

    /// <summary>
    /// 模块列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    public async Task<PagedResultDto<ModuleListDto>> GetListAsync(ModuleInput input, CancellationToken cancellationToken = default)
    {
        var list = await moduleRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, cancellationToken: cancellationToken);
        var totalCount = await moduleRepository.GetCountAsync(input.Filter, cancellationToken);

        var listDto = list.Select(item => new ModuleListDto
        {
            Id = item.Id,
            Name = item.Name,
            DislayName = item.DisplayName,
            Tag = item.GetProperty<ModuleTag?>(PermissionDefinitionConsts.Tag) ?? ModuleTag.Normal
        }).ToList();

        return new PagedResultDto<ModuleListDto>(
            totalCount,
            listDto
        );
    }

    /// <summary>
    /// 模块详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>详情</returns>
    public async Task<ModuleDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await moduleRepository.GetAsync(id, cancellationToken: cancellationToken);
        var moduleDto = new ModuleDto
        {
            Path = entity.GetProperty<string?>(PermissionDefinitionConsts.Path) ?? entity.Name,
            ActiveMenu = entity.GetProperty<string?>(PermissionDefinitionConsts.ActiveMenu),
            Component = entity.GetProperty<string?>(PermissionDefinitionConsts.Component) ?? "#",
            DisplayName = entity.DisplayName,
            Tag = entity.GetProperty<ModuleTag?>(PermissionDefinitionConsts.Tag) ?? ModuleTag.Normal,
            Name = entity.Name,
            Id = entity.Id,
            Redirect = entity.GetProperty<string?>(PermissionDefinitionConsts.Redirect),
            Alias = entity.GetProperty<string?>(PermissionDefinitionConsts.Alias),
            Hidden = entity.GetProperty<bool?>(PermissionDefinitionConsts.Hidden) ?? true,
            AlwaysShow = entity.GetProperty<bool?>(PermissionDefinitionConsts.AlwaysShow),
            Icon = entity.GetProperty<string?>(PermissionDefinitionConsts.Icon),
            NoCache = entity.GetProperty<bool?>(PermissionDefinitionConsts.NoCache),
            Breadcrumb = entity.GetProperty<bool?>(PermissionDefinitionConsts.Breadcrumb),
            Affix = entity.GetProperty<bool?>(PermissionDefinitionConsts.Affix),
            NoTagsView = entity.GetProperty<bool?>(PermissionDefinitionConsts.NoTagsView),
            CanTo = entity.GetProperty<bool?>(PermissionDefinitionConsts.CanTo)
        };
        return moduleDto;
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
        entity.SetProperty(PermissionDefinitionConsts.Title, input.DisplayName);
        entity.SetProperty(PermissionDefinitionConsts.Tag, input.Tag);
    }
}