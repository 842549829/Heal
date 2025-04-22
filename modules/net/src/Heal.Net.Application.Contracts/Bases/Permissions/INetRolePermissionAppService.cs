using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 权限管理
/// </summary>
public interface INetRolePermissionAppService : IHealNetApplicationService
{
    /// <summary>
    /// 获取当前用户路由配置
    /// </summary>
    /// <returns>返回权限树列表</returns>
    Task<List<RouteConfigDto>> GetPermissionTreeListAsync();
}