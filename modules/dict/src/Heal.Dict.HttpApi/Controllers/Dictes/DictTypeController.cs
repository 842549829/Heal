using Heal.Dict.Application.Contracts.Dictes;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Dict.HttpApi.Controllers.Dictes;

/// <summary>
/// 字典类型
/// </summary>
/// <param name="dictTypeAppService">字典类型服务</param>
[Route("api/dict/dictes/type")]
public class DictTypeController(IDictTypeAppService dictTypeAppService) : HealDictController
{
    /// <summary>
    /// 获取字典类型列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    [HttpGet]
    public Task<PagedResultDto<DictTypeDto>> GetListAsync(GetDictTypeInput input, CancellationToken cancellationToken = default)
    {
        return dictTypeAppService.GetListAsync(input, cancellationToken);
    }

    /// <summary>
    /// 创建字典类型
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    [HttpPost]
    public Task<DictTypeDto> CreateAsync([FromBody] DictTypeCreateDto input, CancellationToken cancellationToken = default)
    {
        return dictTypeAppService.CreateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    [HttpPut("{id:guid}")]
    public Task<DictTypeDto> UpdateAsync(Guid id, [FromBody] DictTypeUpdateDto input, CancellationToken cancellationToken = default)
    {
        return dictTypeAppService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 删除字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpDelete("{id:guid}")]
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dictTypeAppService.DeleteAsync(id, cancellationToken);
    }

    /// <summary>
    /// 获取字典类型
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>字典类型</returns>
    [HttpGet("{id:guid}")]
    public Task<DictTypeDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return dictTypeAppService.GetAsync(id, cancellationToken);
    }
}