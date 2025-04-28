using Heal.Domain.Shared.Constants;
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
/// 菜单服务
/// </summary>
public class MenuAppService(IRepository<PermissionDefinitionRecord> permissionDefinitionRecordRepository,
    IMenuRepository menuRepository) : HealNetAppService, IMenuAppService
{
    /// <summary>
    /// 创建菜单
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public async Task CeateAsync(MenuCreateDto input, CancellationToken cancellationToken = default)
    {
        if (await permissionDefinitionRecordRepository.AnyAsync(d => d.Name == input.Name, cancellationToken: cancellationToken))
        {
            throw new UserFriendlyException(L[LocalizedTextsConsts.ModuleAlreadyExists]);
        }
        var entity = new PermissionDefinitionRecord(GuidGenerator.Create(),
            input.Name,
            input.GroupName,
            input.ParentName,
            input.DisplayName,
            input.IsEnabled,
            input.MultiTenancySide,
            input.Providers,
            input.StateCheckers);
        SetProperty(entity, input);
        await permissionDefinitionRecordRepository.InsertAsync(entity, cancellationToken: cancellationToken);
        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;
    }

    /// <summary>
    /// 更新菜单
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public async Task UpdateAsync(Guid id, MenuUpdateDto input, CancellationToken cancellationToken = default)
    {
        var entity = await permissionDefinitionRecordRepository.GetAsync(d => d.Id == id, cancellationToken: cancellationToken);
        entity.DisplayName = input.DisplayName;
        SetProperty(entity, input);
        await permissionDefinitionRecordRepository.UpdateAsync(entity, cancellationToken: cancellationToken);
        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;
    }

    /// <summary>
    /// 菜单列表(分页查询)
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    public async Task<PagedResultDto<MenuListDto>> GetListAsync(MenuInput input, CancellationToken cancellationToken = default)
    {
        var list = await menuRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, cancellationToken: cancellationToken);
        var totalCount = await menuRepository.GetCountAsync(input.Filter, cancellationToken);

        var listDto = list.Select(item => new MenuListDto
        {
            Id = item.Id,
            Name = item.Name,
            DislayName = item.DisplayName,
            GroupName = item.GroupName
        }).ToList();

        return new PagedResultDto<MenuListDto>(
            totalCount,
            listDto
        );
    }

    /// <summary>
    /// 菜单详情
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>详情</returns>
    public async Task<MenuDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await menuRepository.GetAsync(id, cancellationToken: cancellationToken);
        var menuDto = new MenuDto
        {
            Path = entity.GetProperty<string?>(PermissionDefinitionConsts.Path) ?? entity.Name,
            ActiveMenu = entity.GetProperty<string?>(PermissionDefinitionConsts.ActiveMenu),
            Component = entity.GetProperty<string?>(PermissionDefinitionConsts.Component) ?? "#",
            DisplayName = entity.DisplayName,
            Tag = entity.GetProperty<int?>(PermissionDefinitionConsts.Tag) ?? 0,
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
            CanTo = entity.GetProperty<bool?>(PermissionDefinitionConsts.CanTo),
            Title = entity.GetProperty<string?>(PermissionDefinitionConsts.Title) ?? entity.DisplayName,
            PermissionName = entity.ParentName,
            IsEnabled = entity.IsEnabled,
            MultiTenancySide = entity.MultiTenancySide,
            ParentName = entity.ParentName,
            Providers = entity.Providers,
            StateCheckers = entity.StateCheckers,
            Type = entity.GetProperty<PermissionType?>(PermissionDefinitionConsts.Type) ?? PermissionType.Menu,
            GroupName = entity.GroupName
        };
        return menuDto;
    }

    /// <summary>
    /// 设置属性
    /// </summary>
    /// <param name="entity">entity</param>
    /// <param name="input">input</param>
    private static void SetProperty(PermissionDefinitionRecord entity, IMenuCreateOrUpdateDto input)
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
        entity.SetProperty(PermissionDefinitionConsts.Title, input.Title);
        entity.SetProperty(PermissionDefinitionConsts.Tag, input.Tag);
    }
}