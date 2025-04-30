using Heal.Core.Domain.Bases.Organizations.Repositories;
using Heal.Net.Application.Contracts.Bases.Organizations;
using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;

namespace Heal.Net.Application.Bases.Organizations;

/// <summary>
/// 组织机构服务
/// </summary>
/// <param name="organizationUnitManager">组织机构业务管理</param>
/// <param name="organizationDapperRepository">组织机构仓储(Dapper)</param>
public class OrganizationAppService(
    IRepository<OrganizationUnit> organizationRepository,
    OrganizationUnitManager organizationUnitManager,
    IOrganizationDapperRepository organizationDapperRepository)
    : HealNetAppService, IOrganizationAppService
{
    /// <summary>
    /// 创建组织机构
    /// </summary>
    /// <param name="input">组织机构</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    public async Task<OrganizationDto> CreateAsync(OrganizationCreateDto input, CancellationToken cancellationToken = default)
    {
        var organizationUnit = new OrganizationUnit(GuidGenerator.Create(), input.DisplayName, input.ParentId,
            CurrentUser.TenantId);
        input.MapExtraPropertiesTo(organizationUnit);
        await organizationUnitManager.CreateAsync(organizationUnit);
        await CurrentUnitOfWork?.SaveChangesAsync(cancellationToken)!;
        return ObjectMapper.Map<OrganizationUnit, OrganizationDto>(organizationUnit);
    }

    /// <summary>
    /// 更新组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">组织机构</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    public async Task<OrganizationDto> UpdateAsync(Guid id, OrganizationUpdateDto input, CancellationToken cancellationToken = default)
    {
        var organizationUnit = await organizationRepository.GetAsync(a=>a.Id == id, cancellationToken: cancellationToken);
        organizationUnit.DisplayName = input.DisplayName;
        organizationUnit.ConcurrencyStamp = input.ConcurrencyStamp;
        input.MapExtraPropertiesTo(organizationUnit);
        await organizationUnitManager.UpdateAsync(organizationUnit);
        return ObjectMapper.Map<OrganizationUnit, OrganizationDto>(organizationUnit);
    }

    /// <summary>
    /// 获取组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构</returns>
    public async Task<OrganizationDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return ObjectMapper.Map<OrganizationUnit, OrganizationDto>(
            await organizationRepository.GetAsync(a => a.Id == id, cancellationToken: cancellationToken)
        );
    }

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构列</returns>
    public async Task<PagedResultDto<OrganizationTreeDto>> GetListAsync(GetOrganizationsInput input, CancellationToken cancellationToken = default)
    {
        var count = await organizationDapperRepository.GetCountAsync(input.Filter, input.ParentId, cancellationToken);
        var list = await organizationDapperRepository.GetListAsync(input.Sorting,
            input.Filter,
            input.ParentId,
            input.MaxResultCount,
            input.SkipCount, cancellationToken: cancellationToken);

        var data = new PagedResultDto<OrganizationTreeDto>(
            count,
            ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationTreeDto>>(list)
        );

        if (list.Count == 0)
        {
            return data;
        }

        var childList =
            await organizationDapperRepository.GetOrganizationUnitsWithChildCountAsync(list.Select(ca => ca.Id)
                .ToList(), cancellationToken);
        foreach (var item in data.Items)
        {
            foreach (var child in childList.Where(child => child.Id == item.Id))
            {
                item.HasChildren = child.Count > 0;
            }
        }

        return data;
    }

    /// <summary>
    /// 获取组织机构下拉列表
    /// </summary>
    /// <param name="parentId">父级Id</param>
    /// <param name="recursive">是否递归获取所有下级</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构下拉列表</returns>
    public async Task<List<OrganizationDto>> GetSelectAsync(Guid? parentId, bool recursive = false, CancellationToken cancellationToken = default)
    {
        // 检查是否已经请求取消
        cancellationToken.ThrowIfCancellationRequested();
        var list = await organizationUnitManager.FindChildrenAsync(parentId, recursive);
        return ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationDto>>(list);
    }

    /// <summary>
    /// 获取组织机构树形结构
    /// </summary>
    /// <param name="parentId">父级Id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构树形结构</returns>
    public async Task<List<OrganizationTreeDto>> GetTreeAsync(Guid? parentId, CancellationToken cancellationToken = default)
    {
        var list = await organizationUnitManager.FindChildrenAsync(parentId);
        var dtoList = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationTreeDto>>(list);
        var childList =
            await organizationDapperRepository.GetOrganizationUnitsWithChildCountAsync(list.Select(ca => ca.Id)
                .ToList(), cancellationToken);
        foreach (var item in dtoList)
        {
            // 检查是否已经请求取消
            cancellationToken.ThrowIfCancellationRequested();
            foreach (var child in childList.Where(child => child.Id == item.Id))
            {
                // 检查是否已经请求取消
                cancellationToken.ThrowIfCancellationRequested();
                item.HasChildren = child.Count > 0;
            }
        }

        var tree = ConvertSelectOrganization(dtoList, parentId);
        return tree;
    }

    /// <summary>
    /// 删除组织机构
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // 检查是否已经请求取消
        cancellationToken.ThrowIfCancellationRequested();
        await organizationUnitManager.DeleteAsync(id);
    }

    /// <summary>
    /// 转换组织机构
    /// </summary>
    /// <param name="list">组织机构集合</param>
    /// <param name="parentId">父级Id</param>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>组织机构树结构</returns>
    private static List<OrganizationTreeDto> ConvertSelectOrganization(List<OrganizationTreeDto> list, Guid? parentId, CancellationToken cancellationToken = default)
    {
        var arrays = new List<OrganizationTreeDto>();
        var dataList = list.Where(a => a.ParentId == parentId)
            .OrderBy(a => a.Code);
        foreach (var item in dataList)
        {
            // 检查是否已经请求取消
            cancellationToken.ThrowIfCancellationRequested();

            var children = ConvertSelectOrganization(list, item.Id);
            if (children.Count > 0)
            {
                item.Children = children;
                item.HasChildren = true;
            }

            arrays.Add(item);
        }

        return arrays;
    }
}