using Volo.Abp.Users;

namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 当前用户扩展
/// </summary>
public static class CurrentUserExtension
{
    /// <summary>
    /// 获取当前用户名
    /// </summary>
    /// <param name="currentUser">ICurrentUser</param>
    /// <returns>当前用户名</returns>
    public static string? GetCurrentUserName(this ICurrentUser currentUser)
    {
        return currentUser.UserName;
    }
}