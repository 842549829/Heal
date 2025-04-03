namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 扩展方法
/// </summary>
public static class NamingConverterExtension
{
    /// <summary>
    /// 将大驼峰命名（PascalCase）转换为小驼峰命名（camelCase）。
    /// </summary>
    /// <param name="input">输入的字符串。</param>
    /// <returns>转换后的小驼峰命名字符串。</returns>
    public static string ToCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input; // 如果输入为空或 null，直接返回原值。
        }

        // 如果字符串长度为1，直接返回小写形式。
        if (input.Length == 1)
        {
            return input.ToLower();
        }

        // 将首字母转换为小写，拼接剩余部分。
        return char.ToLower(input[0]) + input[1..];
    }

    /// <summary>
    /// 将小驼峰命名（camelCase）转换为大驼峰命名（PascalCase）。
    /// </summary>
    /// <param name="input">输入的字符串。</param>
    /// <returns>转换后的大驼峰命名字符串。</returns>
    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input; // 如果输入为空或 null，直接返回原值。
        }

        // 如果字符串长度为1，直接返回大写形式。
        if (input.Length == 1)
        {
            return input.ToUpper();
        }

        // 将首字母转换为大写，拼接剩余部分。
        return char.ToUpper(input[0]) + input[1..];
    }
}