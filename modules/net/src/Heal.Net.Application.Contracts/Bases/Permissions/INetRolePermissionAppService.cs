using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 权限管理
/// </summary>
public interface INetRolePermissionAppService : IHealNetApplicationService
{
    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <returns>返回模块列表</returns>
    Task<List<ModuleHomeListDto>> GetModuleListAsync();

    /// <summary>
    /// 获取权限树列表
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>返回权限树列表</returns>
    Task<List<RouteConfigDto>> GetPermissionTreeListAsync(string moduleName);
}