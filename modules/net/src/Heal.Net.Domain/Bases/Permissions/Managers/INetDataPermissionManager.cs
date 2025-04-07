using Heal.Domain.Shared.Enums;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 数据权限管理
/// </summary>
public interface INetDataPermissionManager: IHealNetDomainManager
{
    /// <summary>
    /// 获取数据权限
    /// </summary>
    /// <param name="roles">roles</param>
    /// <returns>DataPermission</returns>
    Task<(DataPermission, string[])> GetDataPermissionsAsync(string[] roles);
}