using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 权限管理
/// </summary>
public interface INetRolePermissionAppService : IHealNetApplicationService
{
    /// <summary>
    /// 获取所有权限
    /// </summary>
    /// <returns>所有权限</returns>
    Task<List<PermissionTreeDto>> GetAllPermissionsAsync();

    /// <summary>
    /// 获取当前用户的权限
    /// </summary>
    /// <returns>当前用户的权限</returns>
    Task<List<PermissionTreeDto>> GetCurrentPermissionsAsync();

    /// <summary>
    /// 获取权限组定义
    /// </summary>
    /// <returns>权限组定义</returns>
    Task<List<PermissionGroupDefinitionDto>> GetPermissionGroupDefinitionListAsync();

    /// <summary>
    /// 获取权限定义
    /// </summary>
    /// <param name="groupName">分组名称</param>
    /// <returns>权限定义</returns>
    Task<List<PermissionDefinitionDto>> GetPermissionDefinitionListAsync(string groupName);
}