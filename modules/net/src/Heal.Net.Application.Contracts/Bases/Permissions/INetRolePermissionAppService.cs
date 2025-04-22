using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 权限管理
/// </summary>
public interface INetRolePermissionAppService : IHealNetApplicationService
{
    /// <summary>
    /// 获取模块(当前登录用户有权限的)
    /// </summary>
    /// <returns>模块</returns>
    Task<List<ModuleDto>> GetCurrenModuleListAsync();
    
    /// <summary>
    /// 根据模块名称获取权限(当前登录用户有权限的)
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>权限</returns>
    Task<List<PermissionDto>> GetCurrentPermissionsByModuleNameAsync(string moduleName);
    
    // 获取模块和权限组合树(当前用户的)
}