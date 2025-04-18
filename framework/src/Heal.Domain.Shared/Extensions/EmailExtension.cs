using System.Text.RegularExpressions;

namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 邮箱扩展
/// </summary>
public static class EmailExtension
{
    /// <summary>
    /// 邮箱验证
    /// </summary>
    /// <param name="email">邮箱</param>
    /// <returns>结果</returns>
    public static bool IsValidEmail(string email)
    {
        // 如果邮箱为空，则返回false
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        // 邮箱验证的正则表达式
        const string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        // 使用正则表达式验证邮箱
        return Regex.IsMatch(email, pattern);
    }
}