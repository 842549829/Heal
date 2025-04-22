using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Domain.Bases.Permissions.Managers;
using Heal.Net.Domain.Bases.Permissions.Modules;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// 权限服务
/// </summary>
/// <param name="netRolePermissionManager">角色权限领域接口</param>
public class NetRolePermissionAppService(INetRolePermissionManager netRolePermissionManager) : HealNetAppService, INetRolePermissionAppService
{
    /// <summary>
    /// 获取模块(当前登录用户有权限的)
    /// </summary>
    /// <returns>模块</returns>
    public async Task<List<ModuleDto>> GetCurrenModuleListAsync()
    {
        var moduleList = await netRolePermissionManager.GetModuleListAsync(CurrentUser.Id.GetValueOrDefault());
        return ObjectMapper.Map<List<Module>, List<ModuleDto>>(moduleList);
    }

    /// <summary>
    /// 根据模块名称获取权限(当前登录用户有权限的)
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>权限</returns>
    public async Task<List<PermissionDto>> GetCurrentPermissionsByModuleNameAsync(string moduleName)
    {
        var permissions = await netRolePermissionManager.GetPermissionsAsync(moduleName, CurrentUser.Id.GetValueOrDefault());
        return ObjectMapper.Map<List<Permission>, List<PermissionDto>>(permissions);
    }
}