namespace Heal.Net.Domain.Bases.Permissions.Modules;

/// <summary>
/// 更新权限
/// </summary>
/// <param name="Name">名称</param>
/// <param name="IsGranted">是否被授予</param>
public record UpdatePermission(string Name, bool IsGranted);