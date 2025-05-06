using Heal.Dict.Application.Contracts.Dictes;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.Domain.Dictes.Modules;
using Heal.Dict.Domain.Dictes.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 字典项服务
/// </summary>
/// <param name="dictItemRepository">字典仓储</param>
public class DictItemAppService(IDictItemRepository dictItemRepository)
    : ApplicationService, IDictItemAppService
{
    /// <summary>
    /// 获取字典项列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项列表</returns>
    public async Task<PagedResultDto<DictItemDto>> GetListAsync(GetDictItemInput input, CancellationToken cancellationToken = default)
    {
        var dictItemInput = new DictItemInput
        {
            DictTypeId = input.DictTypeId,
            SkipCount = input.SkipCount,
            MaxResultCount = input.MaxResultCount,
            Sorting = input.Sorting,
            Filter = input.Filter
        };

        var (totalCount, list) = await dictItemRepository.GetListAsync(dictItemInput, cancellationToken);

        return new PagedResultDto<DictItemDto>(
            totalCount,
            ObjectMapper.Map<List<DictItem>, List<DictItemDto>>(list)
        );
    }

    /// <summary>
    /// 创建字典项
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    public async Task<DictItemDto> CreateAsync(DictItemCreateDto input, CancellationToken cancellationToken = default)
    {
        var dictItem = new DictItem(
            GuidGenerator.Create(),
            input.DictTypeId,
            input.Name,
            input.Code,
            input.Key
        );
        dictItem.SetTenant(CurrentUser.TenantId);
        dictItem.SetAlias(input.Alias);
        dictItem.SetParentId(input.ParentId);
        dictItem.SetStyle(input.Style);
        dictItem.SetSort(input.Sort);
        dictItem.SetDescribe(input.Describe);

        await dictItemRepository.InsertAsync(dictItem, cancellationToken: cancellationToken);

        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;

        return ObjectMapper.Map<DictItem, DictItemDto>(dictItem);
    }

    /// <summary>
    /// 更新字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    public async Task<DictItemDto> UpdateAsync(Guid id, DictItemUpdateDto input, CancellationToken cancellationToken = default)
    {
        var dictItem = await dictItemRepository.GetAsync(id, cancellationToken: cancellationToken);

        dictItem.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);
        dictItem.SetName(input.Name);
        dictItem.SetSort(input.Sort);
        dictItem.SetDescribe(input.Describe);
        dictItem.SetStyle(input.Style);
        dictItem.SetAlias(input.Alias);
        dictItem.SetStatus(input.Status);

        input.MapExtraPropertiesTo(dictItem);

        await dictItemRepository.UpdateAsync(dictItem, cancellationToken: cancellationToken);

        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;

        return ObjectMapper.Map<DictItem, DictItemDto>(dictItem);
    }

    /// <summary>
    /// 删除字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await dictItemRepository.DeleteAsync(id, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 获取字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    public async Task<DictItemDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return ObjectMapper.Map<DictItem, DictItemDto>(
            await dictItemRepository.GetAsync(id, cancellationToken: cancellationToken)
        );
    }
}