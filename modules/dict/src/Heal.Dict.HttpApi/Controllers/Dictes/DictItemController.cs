using Heal.Dict.Application.Contracts.Dictes;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.HttpApi.Controllers.Dictes;

/// <summary>
/// 字典项
/// </summary>
/// <param name="dictItemAppService">字典项服务</param>
[Route("api/dict/dictes/item")]
public class DictItemController(IDictItemAppService dictItemAppService) : HealDictController
{
    /// <summary>
    /// 获取字典项
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    [HttpGet]
    public Task<PagedResultDto<DictItemDto>> GetListAsync(GetDictItemInput input, CancellationToken cancellationToken = default)
    {
        return dictItemAppService.GetListAsync(input, cancellationToken);
    }

    /// <summary>
    /// 创建字典项
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    [HttpPost]
    public Task<DictItemDto> CreateAsync([FromBody] DictItemCreateDto input, CancellationToken cancellationToken = default)
    {
        return dictItemAppService.CreateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    [HttpPut("{id:guid}")]
    public Task<DictItemDto> UpdateAsync(Guid id, [FromBody] DictItemUpdateDto input, CancellationToken cancellationToken = default)
    {
        return dictItemAppService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 删除字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dictItemAppService.DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// 获取字典项
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典项</returns>
    [HttpGet("{id:guid}")]
    public Task<DictItemDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dictItemAppService.GetAsync(id, cancellationToken);
    }
}