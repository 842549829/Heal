using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Organizations;

/// <summary>
/// 组织机构服务接口
/// </summary>
public interface IOrganizationAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建组织机构
    /// </summary>
    /// <param name="input">组织机构</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    Task<OrganizationDto> CreateAsync(OrganizationCreateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 更新组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">组织机构</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    Task<OrganizationDto> UpdateAsync(Guid id, OrganizationUpdateDto input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    Task<OrganizationDto> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构列</returns>
    Task<PagedResultDto<OrganizationTreeDto>> GetListAsync(GetOrganizationsInput input, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构下拉列表
    /// </summary>
    /// <param name="parentId">父级Id</param>
    /// <param name="recursive">是否递归获取所有下级</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构下拉列表</returns>
    Task<List<OrganizationDto>> GetSelectAsync(Guid? parentId, bool recursive = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取组织机构树形结构
    /// </summary>
    /// <param name="parentId">父级Id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构树形结构</returns>
    Task<List<OrganizationTreeDto>> GetTreeAsync(Guid? parentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 删除组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}