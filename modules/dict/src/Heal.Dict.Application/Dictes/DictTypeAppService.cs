using Heal.Dict.Application.Contracts.Dictes;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;
using Heal.Dict.Domain.Dictes.Repositories;
using Heal.Domain.Modules;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.ObjectExtending;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 字典类型
/// </summary>
public class DictTypeAppService(IDictTypeRepository dictTypeRepository)
    : ApplicationService, IDictTypeAppService
{
    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    public async Task<PagedResultDto<DictTypeDto>> GetListAsync(GetDictTypeInput input, CancellationToken cancellationToken = default)
    {
        var pagedAndSortedAndFilterInput = new PagedAndSortedAndFilterInput
        {
            SkipCount = input.SkipCount,
            MaxResultCount = input.MaxResultCount,
            Sorting = input.Sorting,
            Filter = input.Filter
        };

        var (totalCount, list) = await dictTypeRepository.GetListAsync(pagedAndSortedAndFilterInput, cancellationToken);

        return new PagedResultDto<DictTypeDto>(
            totalCount,
            ObjectMapper.Map<List<DictType>, List<DictTypeDto>>(list)
        );
    }

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    public async Task<DictTypeDto> CreateAsync(DictTypeCreateDto input, CancellationToken cancellationToken = default)
    {
        var dictType = new DictType(
            GuidGenerator.Create(),
            input.Name,
            input.Code
        );

        dictType.SetTenant(CurrentUser.TenantId);
        dictType.SetParentId(input.ParentId);
        dictType.SetDescribe(input.Describe);
        dictType.SetSort(input.Sort);

        input.MapExtraPropertiesTo(dictType);

        await dictTypeRepository.InsertAsync(dictType, cancellationToken: cancellationToken);

        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;

        return ObjectMapper.Map<DictType, DictTypeDto>(dictType);
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    public async Task<DictTypeDto> UpdateAsync(Guid id, DictTypeUpdateDto input, CancellationToken cancellationToken = default)
    {
        var dictType = await dictTypeRepository.GetAsync(id, cancellationToken: cancellationToken);

        dictType.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        dictType.SetName(input.Name);
        dictType.SetSort(input.Sort);
        dictType.SetDescribe(input.Describe);
        dictType.SetStatus(input.Status);

        input.MapExtraPropertiesTo(dictType);

        await dictTypeRepository.UpdateAsync(dictType, cancellationToken: cancellationToken);

        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;

        return ObjectMapper.Map<DictType, DictTypeDto>(dictType);
    }

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dictTypeRepository.DeleteAsync(id, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// 获取字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    public async Task<DictTypeDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return ObjectMapper.Map<DictType, DictTypeDto>(
            await dictTypeRepository.GetAsync(id, cancellationToken: cancellationToken)
        );
    }
}