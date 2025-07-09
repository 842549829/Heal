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
            throw new UserFriendlyException(L[LocalizedTextsConstants.ModuleAlreadyExists]);
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
        entity.SetProperty(PermissionDefinitionConstants.Type, input.Type);
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
        var list = await menuRepository.GetListAsync(input.ModuleCode, input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, cancellationToken: cancellationToken);
        var totalCount = await menuRepository.GetCountAsync(input.ModuleCode, input.Filter, cancellationToken);
        var menuList = await LoadTreeAsync(list, list.Select(a => a.Name).ToList());
        var menuListDto = BuildTree(menuList, null);
        return new PagedResultDto<MenuListDto>(
            totalCount,
            menuListDto
        );

        async Task<List<PermissionDefinitionRecord>> LoadTreeAsync(List<PermissionDefinitionRecord> currentMenuList, List<string> parentCodes)
        {
            if (!parentCodes.Any())
            {
                return currentMenuList;
            }
            var children = await menuRepository.GetListByParentCodeAsync(parentCodes, cancellationToken);
            currentMenuList.AddRange(children);
            return await LoadTreeAsync(currentMenuList, children.Select(a => a.Name).ToList());
        }

        List<MenuListDto> BuildTree(List<PermissionDefinitionRecord> allMenus, string? parentName)
        {
            return allMenus
                .Where(m => m.ParentName == parentName)
                .Select(menu => new MenuListDto
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    GroupName = menu.GroupName,
                    DislayName = L[menu.DisplayName],
                    Children = BuildTree(allMenus, menu.Name) 
                })
                .ToList();
        }
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
            Path = entity.GetProperty<string?>(PermissionDefinitionConstants.Path) ?? entity.Name,
            ActiveMenu = entity.GetProperty<string?>(PermissionDefinitionConstants.ActiveMenu),
            Component = entity.GetProperty<string?>(PermissionDefinitionConstants.Component) ?? "#",
            DisplayName = entity.DisplayName,
            Tag = entity.GetProperty<int?>(PermissionDefinitionConstants.Tag) ?? 0,
            Name = entity.Name,
            Id = entity.Id,
            Redirect = entity.GetProperty<string?>(PermissionDefinitionConstants.Redirect),
            Alias = entity.GetProperty<string?>(PermissionDefinitionConstants.Alias),
            Hidden = entity.GetProperty<bool?>(PermissionDefinitionConstants.Hidden) ?? true,
            AlwaysShow = entity.GetProperty<bool?>(PermissionDefinitionConstants.AlwaysShow),
            Icon = entity.GetProperty<string?>(PermissionDefinitionConstants.Icon),
            NoCache = entity.GetProperty<bool?>(PermissionDefinitionConstants.NoCache),
            Breadcrumb = entity.GetProperty<bool?>(PermissionDefinitionConstants.Breadcrumb),
            Affix = entity.GetProperty<bool?>(PermissionDefinitionConstants.Affix),
            NoTagsView = entity.GetProperty<bool?>(PermissionDefinitionConstants.NoTagsView),
            CanTo = entity.GetProperty<bool?>(PermissionDefinitionConstants.CanTo),
            Title = entity.GetProperty<string?>(PermissionDefinitionConstants.Title) ?? entity.DisplayName,
            PermissionName = entity.ParentName,
            IsEnabled = entity.IsEnabled,
            MultiTenancySide = entity.MultiTenancySide,
            ParentName = entity.ParentName,
            Providers = entity.Providers,
            StateCheckers = entity.StateCheckers,
            Type = entity.GetProperty<PermissionType?>(PermissionDefinitionConstants.Type) ?? PermissionType.Menu,
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
        entity.SetProperty(PermissionDefinitionConstants.Path, input.Path);
        entity.SetProperty(PermissionDefinitionConstants.Component, input.Component);
        entity.SetProperty(PermissionDefinitionConstants.Redirect, input.Redirect);
        entity.SetProperty(PermissionDefinitionConstants.Alias, input.Alias);
        entity.SetProperty(PermissionDefinitionConstants.Hidden, input.Hidden);
        entity.SetProperty(PermissionDefinitionConstants.AlwaysShow, input.AlwaysShow);
        entity.SetProperty(PermissionDefinitionConstants.Icon, input.Icon);
        entity.SetProperty(PermissionDefinitionConstants.NoCache, input.NoCache);
        entity.SetProperty(PermissionDefinitionConstants.Breadcrumb, input.Breadcrumb);
        entity.SetProperty(PermissionDefinitionConstants.Affix, input.Affix);
        entity.SetProperty(PermissionDefinitionConstants.ActiveMenu, input.ActiveMenu);
        entity.SetProperty(PermissionDefinitionConstants.NoTagsView, input.NoTagsView);
        entity.SetProperty(PermissionDefinitionConstants.CanTo, input.CanTo);
        entity.SetProperty(PermissionDefinitionConstants.Title, input.Title);
        entity.SetProperty(PermissionDefinitionConstants.Tag, input.Tag);
    }
}