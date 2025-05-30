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
            throw new UserFriendlyException(L[LocalizedTextsConstants.ModuleAlreadyExists]);
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
            DislayName = L[item.DisplayName],
            Tag = item.GetProperty<ModuleTag?>(PermissionDefinitionConstants.Tag) ?? ModuleTag.Normal
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
            Path = entity.GetProperty<string?>(PermissionDefinitionConstants.Path) ?? entity.Name,
            ActiveMenu = entity.GetProperty<string?>(PermissionDefinitionConstants.ActiveMenu),
            Component = entity.GetProperty<string?>(PermissionDefinitionConstants.Component) ?? "#",
            DisplayName = entity.DisplayName,
            Tag = entity.GetProperty<ModuleTag?>(PermissionDefinitionConstants.Tag) ?? ModuleTag.Normal,
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
            CanTo = entity.GetProperty<bool?>(PermissionDefinitionConstants.CanTo)
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
        entity.SetProperty(PermissionDefinitionConstants.Path, input.Path);
        entity.SetProperty(PermissionDefinitionConstants.Component, input.Component);
        entity.SetProperty(PermissionDefinitionConstants.Type, PermissionType.Module);
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
        entity.SetProperty(PermissionDefinitionConstants.Title, input.DisplayName);
        entity.SetProperty(PermissionDefinitionConstants.Tag, input.Tag);
    }
}