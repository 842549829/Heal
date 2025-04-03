using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using ITenantAppService = Heal.Net.Application.Contracts.Bases.Tenants.ITenantAppService;

namespace Heal.Net.Application.Bases.Tenants;

/// <summary>
/// 租户服务管理
/// </summary>
/// <param name="tenantManager">租户管理</param>
/// <param name="tenantRepository">租户仓储</param>
/// <param name="distributedEventBus">分布式事件</param>
/// <param name="dataSeeder">种子数据服务</param>
public class TenantAppService(
    ITenantManager tenantManager,
    ITenantRepository tenantRepository,
    IDistributedEventBus distributedEventBus,
    IDataSeeder dataSeeder)
    : HealNetAppService, ITenantAppService
{
    /// <summary>
    /// 获取租户
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>租户</returns>
    public async Task<TenantDto> GetAsync(Guid id)
    {
        return ObjectMapper.Map<Tenant, TenantDto>(
            await tenantRepository.GetAsync(id)
        );
    }

    /// <summary>
    /// 获取租户列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>租户列表</returns>
    public async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Tenant.Name);
        }

        var count = await tenantRepository.GetCountAsync(input.Filter);
        var list = await tenantRepository.GetListAsync(
            input.Sorting,
            input.MaxResultCount,
            input.SkipCount,
            input.Filter
        );

        return new PagedResultDto<TenantDto>(
            count,
            ObjectMapper.Map<List<Tenant>, List<TenantDto>>(list)
        );
    }

    /// <summary>
    /// 创建租户
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns>租户实体</returns>
    public async Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        var tenant = await tenantManager.CreateAsync(input.Name);
        input.MapExtraPropertiesTo(tenant);

        await tenantRepository.InsertAsync(tenant);

        await CurrentUnitOfWork?.SaveChangesAsync()!;

        await distributedEventBus.PublishAsync(
            new TenantCreatedEto
            {
                Id = tenant.Id,
                Name = tenant.Name,
                Properties =
                {
                    { "AdminEmail", input.AdminEmailAddress },
                    { "AdminPassword", input.AdminPassword }
                }
            });

        using (CurrentTenant.Change(tenant.Id, tenant.Name))
        {
            await dataSeeder.SeedAsync(
                new DataSeedContext(tenant.Id)
                    .WithProperty("AdminEmail", input.AdminEmailAddress)
                    .WithProperty("AdminPassword", input.AdminPassword)
            );
        }

        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    }

    /// <summary>
    /// 更新租户
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">租户信息</param>
    /// <returns>租户实体</returns>
    public async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    {
        var tenant = await tenantRepository.GetAsync(id);

        await tenantManager.ChangeNameAsync(tenant, input.Name);

        tenant.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);
        input.MapExtraPropertiesTo(tenant);

        await tenantRepository.UpdateAsync(tenant);

        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    }

    /// <summary>
    /// 删除租户
    /// </summary>
    /// <param name="id">租户Id</param>
    /// <returns>Task</returns>
    public async Task DeleteAsync(Guid id)
    {
        var tenant = await tenantRepository.FindAsync(id);
        if (tenant == null)
        {
            return;
        }

        await tenantRepository.DeleteAsync(tenant);
    }
}