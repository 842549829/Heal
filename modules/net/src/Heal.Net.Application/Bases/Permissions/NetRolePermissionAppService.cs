using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Domain.Bases.Permissions.Managers;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// 权限服务
/// </summary>
/// <param name="netRolePermissionManager">角色权限领域接口</param>
public class NetRolePermissionAppService(INetRolePermissionManager netRolePermissionManager) : HealNetAppService, INetRolePermissionAppService
{
    /// <summary>
    /// 获取所有权限
    /// </summary>
    /// <returns>所有权限</returns>
    public async Task<List<PermissionTreeDto>> GetAllPermissionsAsync()
    {
        var permissionTree = await netRolePermissionManager.GetAllPermissionTreeListAsync();
        return ObjectMapper.Map<List<PermissionTree>, List<PermissionTreeDto>>(permissionTree);
    }

    /// <summary>
    /// 获取当前用户的权限
    /// </summary>
    /// <returns>当前用户的权限</returns>
    public async Task<List<PermissionTreeDto>> GetCurrentPermissionsAsync()
    {
        var permissionTree = await netRolePermissionManager.GetPermissionTreeListAsync(CurrentUser.Id.GetValueOrDefault());
        return ObjectMapper.Map<List<PermissionTree>, List<PermissionTreeDto>>(permissionTree);
    }

    /// <summary>
    /// 获取权限组定义
    /// </summary>
    /// <returns>权限组定义</returns>
    public async Task<List<PermissionGroupDefinitionDto>> GetPermissionGroupDefinitionListAsync()
    {
        var permissionGroupDefinitionRecords = await netRolePermissionManager.GetPermissionGroupDefinitionListAsync();
        var permissionGroupDefinitionList = ObjectMapper.Map<List<PermissionGroupDefinitionRecord>, List<PermissionGroupDefinitionDto>>(permissionGroupDefinitionRecords);
        return permissionGroupDefinitionList;
    }

    /// <summary>
    /// 获取权限定义
    /// </summary>
    /// <param name="groupName">分组名称</param>
    /// <returns>权限定义</returns>
    public async Task<List<PermissionDefinitionDto>> GetPermissionDefinitionListAsync(string groupName)
    {
        var permissionDefinitionRecords = await netRolePermissionManager.GetPermissionDefinitionListAsync(groupName);
        var permissionDefinitionList = ObjectMapper.Map<List<PermissionDefinitionRecord>, List<PermissionDefinitionDto>>(permissionDefinitionRecords);
        return permissionDefinitionList;
    }
}