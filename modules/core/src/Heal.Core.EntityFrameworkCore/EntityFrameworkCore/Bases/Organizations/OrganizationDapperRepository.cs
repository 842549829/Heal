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
                       -- 使用递归 CTE 查找匹配过滤条件的组织单元及其所有上级父级
                       WITH _parent(Id,ParentId) -- 显式列出 AbpOrganizationUnits 表的所有列（根据实际情况调整）
                       AS
                       (
                       -- 锚点成员：查找符合初始条件的组织单元
                       SELECT 
                       fun.Id,
                       fun.ParentId
                       FROM AbpOrganizationUnits fun  -- 替换为实际的表名
                       {sqlCondition}

                       UNION ALL

                       -- 递归成员：查找当前层级记录的父级
                       SELECT 
                       fun.Id,
                       fun.ParentId
                       FROM _parent -- 引用 CTE 自身
                       INNER JOIN AbpOrganizationUnits fun ON fun.Id = _parent.ParentId -- 显式内连接到父级记录
                       WHERE 
                       fun.IsDeleted = 0 
                       )

                       -- 最终查询：计算找到的顶级（无父级）组织单元的数量
                       -- （即，初始匹配项及其祖先链中最顶层的那些）
                       SELECT COUNT(*) AS TotalTopLevelCount
                       FROM (
                       SELECT COUNT(*) AS DummyCount -- 内层 COUNT 实际上是为了分组，外层 COUNT 计算顶级节点数
                       FROM _parent 
                       WHERE _parent.ParentId IS NULL 
                       GROUP BY _parent.Id -- 每个顶级节点分一组
                       ) AS T; -- 必须给派生表 T 起别名
                       """;

            return await connection.QueryFirstOrDefaultAsync<long>(sql, new { filter = $"%{filter}%", parentId },
                transaction);
        }
        else
        {
            var queryParams = new DynamicParameters();
            var sqlCondition = new StringBuilder();
            SetTenantIdParams(sqlCondition, queryParams);
            var sql = $"SELECT COUNT(*) FROM [AbpOrganizationUnits] WHERE IsDeleted = 0 {sqlCondition} AND ParentId IS NULL";
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
                        -- 使用递归 CTE 查找匹配过滤条件的组织单元及其所有上级父级
                        WITH _parent AS
                        (
                          -- 锚点成员：查找符合初始条件的组织单元
                          SELECT fun.*
                          FROM [AbpOrganizationUnits] fun
                          WHERE fun.IsDeleted = 0  
                            AND fun.TenantId IS NULL 
                            AND fun.DisplayName LIKE @filter 
                        
                          UNION ALL
                        
                          -- 递归成员：查找当前层级记录的父级
                          SELECT fun.*
                          FROM _parent -- 引用 CTE 自身
                          INNER JOIN [AbpOrganizationUnits] fun ON fun.Id = _parent.ParentId -- 显式内连接到父级记录
                          WHERE fun.IsDeleted = 0 -- 检查父级是否被删除
                        )
                        
                        -- 最终查询：选择所有顶级节点（即初始匹配及其祖先链的顶端），去重，按 Code 排序，分页
                        SELECT DISTINCT * -- 对所有列进行去重
                        FROM _parent
                        WHERE _parent.ParentId IS NULL -- 筛选顶级节点
                        ORDER BY [Code] -- 按 Code 排序
                        -- 分页 (SQL Server 2012+ 语法)
                        OFFSET @skipCount ROWS      -- 跳过 @skipCount 行
                        FETCH NEXT @maxResultCount ROWS ONLY; -- 获取接下来的 @maxResultCount 行
                        """;
            return (await QueryAsync(connection, sql, queryParams, transaction)).ToList();
        }
        else
        {
            var sqlCondition = new StringBuilder();
            SetTenantIdParams(sqlCondition, queryParams);
            var sql =
                $"SELECT * FROM [AbpOrganizationUnits] WHERE IsDeleted = 0 {sqlCondition} AND ParentId IS NULL ORDER BY [Code] OFFSET @skipCount ROWS FETCH NEXT @maxResultCount ROWS ONLY;";
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
            $"SELECT ParentId AS [Id], COUNT(0) AS [Count] FROM AbpOrganizationUnits WHERE IsDeleted = 0 {sqlCondition} AND ParentId IN @parentIds GROUP BY ParentId";
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
            organizationUnit.ConcurrencyStamp = item.ConcurrencyStamp;
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