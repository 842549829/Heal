using Heal.Net.Application.Contracts.Bases.Departments;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 科室控制器
/// </summary>
/// <param name="departmentService">departmentService</param>
[Microsoft.AspNetCore.Components.Route("api/net/basics/department")]
public class DepartmentController(IDepartmentService departmentService) : HealNetController
{
    /// <summary>
    /// 创建
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    [HttpPost]
    public Task<DepartmentDto> CreateAsync([FromBody] DepartmentCreateDto input, CancellationToken cancellationToken)
    {
        return departmentService.CreateAsync(input, cancellationToken);
    }

    /// <summary>
    /// 更新科室
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="input">科室更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    [HttpPut("{id:guid}")]
    public Task<DepartmentDto> UpdateAsync(Guid id, [FromBody] DepartmentUpdateDto input,
        CancellationToken cancellationToken = default)
    {
        return departmentService.UpdateAsync(id, input, cancellationToken);
    }

    /// <summary>
    /// 获取列表
    /// </summary>
    /// <param name="input">输入</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室列表</returns>
    [HttpGet]
    public Task<PagedResultDto<DepartmentListDto>> GetListAsync([FromQuery] DepartmentInput input,
        CancellationToken cancellationToken = default)
    {
        return departmentService.GetListAsync(input, cancellationToken);
    }
    
    /// <summary>
    /// 获取
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    [HttpGet("detail/{id:guid}")]
    public Task<DepartmentDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return departmentService.GetAsync(id, cancellationToken);
    }
    
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>Task</returns>
    [HttpDelete("{id:guid}")]
    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return departmentService.DeleteAsync(id, cancellationToken);
    }
}