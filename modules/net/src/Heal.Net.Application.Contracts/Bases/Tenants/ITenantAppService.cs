using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement;

namespace Heal.Net.Application.Contracts.Bases.Tenants;

/// <summary>
/// 租户服务接口
/// </summary>
public interface ITenantAppService : IApplicationService
{
    /// <summary>
    /// 获取租户
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>租户</returns>
    Task<TenantDto> GetAsync(Guid id);

    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>租户列表</returns>
    Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input);

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns>租户实体</returns>
    Task<TenantDto> CreateAsync(TenantCreateDto input);

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">租户信息</param>
    /// <returns>租户实体</returns>
    Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input);

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户Id</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id);
}