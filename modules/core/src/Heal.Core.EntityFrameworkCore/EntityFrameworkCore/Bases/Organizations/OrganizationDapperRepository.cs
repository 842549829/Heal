using Dapper;
using Heal.Core.Domain.Bases.Organizations.Models;
using Heal.Core.Domain.Bases.Organizations.Repositories;
using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using System.Data;
using System.Text;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Users;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Organizations;

/// <summary>
/// 组织机构数据仓储
/// </summary>
/// <param name="dbContextProvider">数据提供集</param>
public class OrganizationDapperRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider)
    : DapperRepository<IIdentityDbContext>(dbContextProvider), IOrganizationDapperRepository
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    protected ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    /// <summary>
    /// 获取组织机构数量
    /// </summary>
    /// <param name="filter">关键词</param>
    /// <param name="parentId">父级Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>数量</returns>
    public async Task<long> GetCountAsync(string? filter = null, Guid? parentId = null,
        CancellationToken cancellationToken = default)
    {
        var connection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();

        if (filter != null || parentId.HasValue)
        {
            var queryParams = new DynamicParameters();
            var sqlCondition = new StringBuilder();
            sqlCondition.Append(" WHERE fun.IsDeleted = 0 ");
            SetTenantIdParams(sqlCondition, queryParams, "fun.");
            if (parentId.HasValue)
            {
                queryParams.Add("parentId", parentId);
                sqlCondition.Append(" AND fun.ParentId = @parentId ");
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                queryParams.Add("filter", $"%{filter}%");
                sqlCondition.Append(" AND fun.DisplayName LIKE @filter ");
            }

            var sql = $"""
                       WITH RECURSIVE _parent AS
                       (
                        SELECT fun.* FROM `abporganizationunits` fun {sqlCondition}
                           UNION ALL
                        SELECT fun.* FROM _parent,`abporganizationunits` fun WHERE fun.IsDeleted = 0 AND fun.Id=_parent.ParentId
                       )
                       SELECT COUNT(*) FROM (
                       SELECT COUNT(*) FROM _parent WHERE _parent.ParentId IS NULL GROUP BY _parent.Id) AS T;
                       """;

            return await connection.QueryFirstOrDefaultAsync<long>(sql, new { filter = $"%{filter}%", parentId },
                transaction);
        }
        else
        {
            var queryParams = new DynamicParameters();
            var sqlCondition = new StringBuilder();
            SetTenantIdParams(sqlCondition, queryParams);
            var sql = $"SELECT COUNT(*) FROM `AbpOrganizationUnits` WHERE IsDeleted = 0 {sqlCondition} AND ParentId IS NULL";
            return await connection.QueryFirstOrDefaultAsync<long>(sql, queryParams, transaction);
        }
    }

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="sorting">排序字段</param>
    /// <param name="filter">关键词</param>
    /// <param name="parentId">父级Id</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="includeDetails">是否加载子对象</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>组织机构列表</returns>
    public async Task<List<OrganizationUnit>> GetListAsync(string? sorting, string? filter = null, Guid? parentId = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var connection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();

        var queryParams = new DynamicParameters();
        queryParams.Add("skipCount", skipCount);
        queryParams.Add("maxResultCount", maxResultCount);

        if (filter != null || parentId.HasValue)
        {
            var sqlCondition = new StringBuilder();
            sqlCondition.Append(" WHERE fun.IsDeleted = 0 ");
            SetTenantIdParams(sqlCondition, queryParams, "fun.");
            if (parentId.HasValue)
            {
                queryParams.Add("parentId", parentId);
                sqlCondition.Append(" AND fun.ParentId = @parentId ");
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                queryParams.Add("filter", $"%{filter}%");
                sqlCondition.Append(" AND fun.DisplayName LIKE @filter ");
            }

            var sql = $"""
                       WITH RECURSIVE _parent AS
                       (
                        SELECT fun.* FROM `AbpOrganizationUnits` fun {sqlCondition}
                           UNION ALL
                        SELECT fun.* FROM _parent,`AbpOrganizationUnits` fun WHERE fun.IsDeleted = 0 AND fun.Id=_parent.ParentId
                       )
                       SELECT DISTINCT * FROM _parent WHERE _parent.ParentId IS NULL ORDER BY `Code` LIMIT @skipCount, @maxResultCount;
                       """;
            return (await QueryAsync(connection, sql, queryParams, transaction)).ToList();
        }
        else
        {
            var sqlCondition = new StringBuilder();
            SetTenantIdParams(sqlCondition, queryParams);
            var sql =
                $"SELECT * FROM `AbpOrganizationUnits` WHERE IsDeleted = 0 {sqlCondition} AND ParentId IS NULL ORDER BY `Code` LIMIT @skipCount, @maxResultCount";
            return (await QueryAsync(connection, sql, queryParams, transaction)).ToList();
        }
    }

    /// <summary>
    /// 获取组织机构列表
    /// </summary>
    /// <param name="parentIds">父级Id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>组织机构树节点</returns>
    public async Task<List<OrganizationWithChildCount>> GetOrganizationUnitsWithChildCountAsync(List<Guid> parentIds,
        CancellationToken cancellationToken = default)
    {
        var queryParams = new DynamicParameters();
        queryParams.Add("parentIds", parentIds);
        var sqlCondition = new StringBuilder();
        SetTenantIdParams(sqlCondition, queryParams);
        var sql =
            $"SELECT ParentId AS `id`, COUNT(0) AS `count` FROM AbpOrganizationUnits WHERE IsDeleted = 0 {sqlCondition} AND ParentId IN @parentIds GROUP BY ParentId";
        var connection = await GetDbConnectionAsync();
        var transaction = await GetDbTransactionAsync();
        return (await connection.QueryAsync<OrganizationWithChildCount>(sql, queryParams,
            transaction)).ToList();
    }

    /// <summary>
    /// 设置租户Id参数
    /// </summary>
    /// <param name="sqlCondition">条件</param>
    /// <param name="queryParams">参数</param>
    /// <param name="alias">别名</param>
    private void SetTenantIdParams(StringBuilder sqlCondition, DynamicParameters queryParams, string alias = "")
    {
        if (CurrentUser.TenantId.HasValue)
        {
            sqlCondition.Append($" AND {alias}TenantId = @tenantId ");
            queryParams.Add("tenantId", CurrentUser.TenantId.Value);
        }
        else
        {
            sqlCondition.Append($" AND {alias}TenantId IS NULL");
        }
    }

    /// <summary>
    /// 组织机构Mapper
    /// </summary>
    /// <param name="connection">连接</param>
    /// <param name="sql">sql</param>
    /// <param name="queryParams">参数</param>
    /// <param name="transaction">事务</param>
    /// <returns>结果</returns>
    private static async Task<IEnumerable<OrganizationUnit>> QueryAsync(IDbConnection connection, string sql, DynamicParameters queryParams, IDbTransaction? transaction)
    {
        var result = await connection.QueryAsync<dynamic>(sql, queryParams, transaction);

        var organizationUnitList = new List<OrganizationUnit>();
        foreach (var item in result)
        {
            var organizationUnit = new OrganizationUnit(item.Id, item.DisplayName, item.ParentId, item.TenantId);
            EntityExtension.TrySetOrganizationCode(organizationUnit, item.Code);

            if (item.Phone != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Phone, item.Phone);
            }

            if (item.EstablishmentDate != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.EstablishmentDate, item.EstablishmentDate);
            }

            if (item.Email != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Email, item.Email);
            }

            if (item.WebsiteUrl != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.WebsiteUrl, item.WebsiteUrl);
            }

            if (item.Address != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Address, item.Address);
            }

            if (item.PostalCode != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.PostalCode, item.PostalCode);
            }

            if (item.ServiceHotline != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.ServiceHotline, item.ServiceHotline);
            }

            if (item.Introduction != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Introduction, item.Introduction);
            }

            if (item.TrafficGuide != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.TrafficGuide, item.TrafficGuide);
            }

            if (item.ParkingInformation != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.ParkingInformation, item.ParkingInformation);
            }

            if (item.Describe != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Describe, item.Describe);
            }

            if (item.Latitude != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Latitude, item.Latitude);
            }

            if (item.Longitude != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Longitude, item.Longitude);
            }

            if (item.CoverImage != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.CoverImage, item.CoverImage);
            }

            if (item.Facilities != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.Facilities, item.Facilities);
            }

            if (item.OperatingHours != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.OperatingHours, item.OperatingHours);
            }

            if (item.IsEmergencyServices != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.IsEmergencyServices, item.IsEmergencyServices);
            }

            if (item.IsInsuranceAccepted != null)
            {
                organizationUnit.ExtraProperties.Add(OrganizationUnitExtensionConstants.IsInsuranceAccepted, item.IsInsuranceAccepted);
            }

            organizationUnitList.Add(organizationUnit);
        }
        return organizationUnitList;
    }
}