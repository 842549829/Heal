using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 权限控制器
/// </summary>
/// <param name="permissionAppService">权限管理</param>
[Route("api/net/basics/permissions")]
[ApiController]
public class PermissionController(INetRolePermissionAppService permissionAppService) : HealNetController
{
    /// <summary>
    /// 获取权限树列表
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>路由</returns>
    [HttpGet("routes/{moduleName}")]
    public Task<List<RouteConfigDto>> GetPermissionTreeListAsync(string moduleName)
    {
        return permissionAppService.GetPermissionTreeListAsync(moduleName);
    }

    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <returns>模块列表</returns>
    [HttpGet("module-list")]
    public Task<List<ModuleHomeListDto>> GetModuleListAsync()
    {
        return permissionAppService.GetModuleListAsync();
    }

    /// <summary>
    /// 获取所有权限菜单列表
    /// </summary>
    /// <returns>所有权限菜单列表</returns>
    [HttpGet("role-list")]
    public Task<List<RolePermissionTreeDto>> GetAllRolePermissionTreeListAsync()
    {
        return permissionAppService.GetAllRolePermissionTreeListAsync();
    }
}