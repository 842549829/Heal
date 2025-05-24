using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Departments;

/// <summary>
/// 科室服务接口
/// </summary>
public interface IDepartmentService : IHealNetApplicationService
{
    /// <summary>
    /// 创建科室
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    Task<DepartmentDto> CreateAsync(DepartmentCreateDto input, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 科室分页查询
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室列表</returns>
    Task<PagedResultDto<DepartmentListDto>> GetListAsync(DepartmentInput input, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 更新科室    
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    Task<DepartmentDto> UpdateAsync(Guid id, DepartmentUpdateDto input, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 获取科室
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    Task<DepartmentDto> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// 删除科室
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}