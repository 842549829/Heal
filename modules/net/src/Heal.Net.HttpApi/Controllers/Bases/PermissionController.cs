using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    /// 获取模块(当前登录用户有权限的)
    /// </summary>
    /// <returns>模块</returns>
    [HttpGet("model-list")]
    public async Task<List<ModuleDto>> GetCurrenModuleListAsync()
    {
        var moduleList = await permissionAppService.GetCurrenModuleListAsync();
        return moduleList;
    }

    /// <summary>
    /// 根据模块名称获取权限(当前登录用户有权限的)
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>权限</returns>
    [HttpGet("permission-list")]
    public async Task<List<PermissionDto>> GetCurrentPermissionsByModuleNameAsync(string moduleName)
    {
        var permissions = await permissionAppService.GetCurrentPermissionsByModuleNameAsync(moduleName);
        return permissions;
    }
}