using Heal.Domain.Shared.Enums;

namespace Heal.Net.Domain.Bases.Permissions.Modules;

/// <summary>
/// 权限树
/// </summary>
/// <param name="name">权限名称</param>
/// <param name="displayName">权限显示名称</param>
/// <param name="type">权限类型</param>
/// <param name="path">权限前端路由</param>
/// <param name="iocn">权限前端图标</param>
/// <param name="parentName">权限名称</param>
public class PermissionTree(
    string name,
    string? displayName,
    PermissionType? type,
    string? path = null,
    string? iocn = null,
    string? parentName = null)
{
    /// <summary>
    /// 权限名称
    /// </summary>
    public string Name { get; private set; } = name;

    /// <summary>
    /// 父级权限名称
    /// </summary>
    public string? ParentName { get; private set; } = parentName;

    /// <summary>
    /// 权限前端路由
    /// </summary>
    public string? Path { get; set; } = path;

    /// <summary>
    /// 权限前端图标
    /// </summary>
    public string? Iocn { get; set; } = iocn;

    /// <summary>
    /// 权限显示名称
    /// </summary>
    public string? DisplayName { get; private set; } = displayName;

    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType? Type { get; private set; } = type;

    /// <summary>
    /// 子权限
    /// </summary>
    public List<PermissionTree> ChildPermissions { get; } = [];

    /// <summary>
    /// 添加子权限
    /// </summary>
    /// <param name="child">子权限</param>
    public void AddChildPermissions(PermissionTree child)
    {
        ChildPermissions.Add(child);
    }
}