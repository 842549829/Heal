using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Net.Domain.Bases.Roles.Repositories;
using Volo.Abp.Data;
using Volo.Abp.Json;

namespace Heal.Net.Domain.Bases.Permissions.Managers;

/// <summary>
/// 数据权限管理
/// </summary>
public class NetDataPermissionManager(IRoleExtensionRepository roleExtensionRepository, IJsonSerializer jsonSerializer) : HealNetDomainManager, INetDataPermissionManager
{
    /// <summary>
    /// 获取数据权限
    /// </summary>
    /// <param name="roles">roles</param>
    /// <returns>DataPermission</returns>
    public async Task<(DataPermission, string[])> GetDataPermissionsAsync(string[] roles)
    {
        // 如果没有传入角色，直接返回无权限
        if (roles.Length == 0)
        {
            return (DataPermission.None, []);
        }

        // 获取角色扩展信息
        var roleExtensions = await roleExtensionRepository.GetRoleAsync(roles);

        // 如果没有角色扩展信息，则返回无权限
        if (roleExtensions.Count == 0 )
        {
            return (DataPermission.None, []);
        }

        // 定义权限优先级
        var priorityPermissions = new[]
        {
            DataPermission.All,
            DataPermission.CurAndSub,
            DataPermission.Cur,
            DataPermission.Sub
        };

        // 按优先级判断数据权限
        foreach (var permission in priorityPermissions)
        {
            if (roleExtensions.Any(d => d.GetProperty<DataPermission>(IdentityRoleExtensionConsts.DataPermission) == permission))
            {
                return (permission, []);
            }
        }

        // 处理自定义权限（使用 HashSet 去重）
        var customValuesSet = new HashSet<string>();
        foreach (var role in roleExtensions)
        {
            if (role.GetProperty<DataPermission>(IdentityRoleExtensionConsts.DataPermission) == DataPermission.Custom)
            {
                var customDataPermissions = role.GetProperty<string>(IdentityRoleExtensionConsts.CustomDataPermission);
                if (customDataPermissions == null)
                {
                    continue;
                }
                var values = jsonSerializer.Deserialize<string[]>(customDataPermissions);
                foreach (var value in values)
                {
                    customValuesSet.Add(value); // 自动去重
                }
            }
        }

        var customValues = customValuesSet.ToArray();

        return customValues.Length > 0
            ? (DataPermission.Custom, customValues)
            : (DataPermission.None, []);
    }
}