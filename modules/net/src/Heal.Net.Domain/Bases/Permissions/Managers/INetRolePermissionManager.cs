﻿using Heal.Net.Domain.Bases.Permissions.Modules;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 角色权限领域接口
/// </summary>
public interface INetRolePermissionManager : IHealNetDomainManager
{
    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="name">角色名称</param>
    /// <param name="updatePermissions">更新权限</param>
    /// <returns>角色</returns>
    Task SetPermissionAsync(
        string name,
        List<UpdatePermission> updatePermissions);

    /// <summary>
    /// 异步获取权限授予列表
    /// </summary>
    /// <param name="providerName">权限提供者名称</param>
    /// <param name="providerKey">权限提供者密钥</param>
    /// <param name="cancellationToken">用于取消任务的令牌</param>
    /// <returns>返回权限授予列表</returns>
    Task<List<PermissionGrant>> GetPermissionGrantListAsync(
            string providerName,
            string providerKey,
            CancellationToken cancellationToken = default
        );

    /// <summary>
    /// 获取模块和权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="groupName">组名称</param>
    /// <returns>返回权限树列表</returns>
    Task<List<PermissionTree>> GetModuleAndPermissionTreeListAsync(Guid? userId = null, string? groupName = null);

    /// <summary>
    /// 获取权限树列表
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <param name="groupName">组名称</param>
    /// <returns>返回权限树列表</returns>
    Task<List<PermissionTree>> GetPermissionTreeListAsync(Guid? userId = null, string? groupName = null);

    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <param name="userId">用户Id</param>
    /// <returns>权限</returns>
    Task<List<Permission>> GetModuleListAsync(Guid? userId = null);

    /// <summary>
    /// 获取所有的模块菜单按钮权限
    /// </summary>
    /// <param name="userId">当前登录用户Id</param>
    /// <returns>权限树</returns>
    Task<List<PermissionTree>> GetAllPermissionTreeListAsync(Guid? userId = null);
}