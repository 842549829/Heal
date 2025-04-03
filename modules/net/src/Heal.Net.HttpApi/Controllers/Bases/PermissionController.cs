using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Heal.Net.HttpApi.Controllers.Bases;

/// <summary>
/// 权限控制器
/// </summary>
/// <param name="permissionAppService">权限管理</param>
[Route("api/net/basics")]
[ApiController]
public class PermissionController(INetRolePermissionAppService permissionAppService) : HealNetController
{
    /// <summary>
    /// 获取所有权限
    /// </summary>
    /// <returns>所有权限</returns>
    [HttpGet("all")]
    public Task<List<PermissionTreeDto>> GetAllPermissionsAsync()
    {
        return permissionAppService.GetAllPermissionsAsync();
    }

    /// <summary>
    /// 获取当前用户的权限
    /// </summary>
    /// <returns>当前用户的权限</returns>
    [HttpGet("curr")]
    public Task<List<PermissionTreeDto>> GetCurrentPermissionsAsync()
    {
        return permissionAppService.GetCurrentPermissionsAsync();
    }

    /// <summary>
    /// 获取权限组
    /// </summary>
    /// <returns>权限组</returns>
    [HttpGet("group")]
    public Task<List<PermissionGroupDefinitionDto>> GetPermissionGroupDefinitionListAsync()
    {
        return permissionAppService.GetPermissionGroupDefinitionListAsync();
    }

    /// <summary>
    /// 获取权限定义
    /// </summary>
    /// <param name="groupName">分组名称</param>
    /// <returns>权限定义</returns>
    [HttpGet("definition/{groupName}")]
    public Task<List<PermissionDefinitionDto>> GetPermissionDefinitionListAsync(string groupName)
    {
        return permissionAppService.GetPermissionDefinitionListAsync(groupName);
    }
}