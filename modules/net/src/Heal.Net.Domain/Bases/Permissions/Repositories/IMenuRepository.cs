﻿using Heal.Domain.Repositories;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Repositories;

/// <summary>
/// 菜单仓储
/// </summary>
public interface IMenuRepository : IHealRepository, IBasicRepository<PermissionDefinitionRecord, Guid>
{
    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// <param name="groupName">分组信息</param>
    /// <param name="sorting">排序字段</param>
    /// <param name="maxResultCount">最大条数</param>
    /// <param name="skipCount">跳过条数</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>列表</returns>
    Task<List<PermissionDefinitionRecord>> GetListAsync(
        string groupName,
        string? sorting = null,
        int maxResultCount = int.MaxValue,
        int skipCount = 0,
        string? filter = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// 根据父级编码获取菜单列表
    /// </summary>
    /// <param name="parentCode">parentCode</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    Task<List<PermissionDefinitionRecord>> GetListByParentCodeAsync(List<string> parentCode, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取菜单总数
    /// </summary>
    /// <param name="groupName">分组信息</param>
    /// <param name="filter">过滤条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>总数</returns>
    Task<long> GetCountAsync(
        string groupName,
        string? filter = null,
        CancellationToken cancellationToken = default
    );
}