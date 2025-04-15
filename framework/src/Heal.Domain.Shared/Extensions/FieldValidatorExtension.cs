namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 字段验证扩展
/// </summary>
public static class FieldValidatorExtension
{
    /// <summary>
    /// 验证字段长度范围
    /// </summary>
    /// <param name="field">字段值</param>
    /// <param name="fieldName">字段名称（用于错误信息）</param>
    /// <param name="minLength">最小允许长度</param>
    /// <param name="maxLength">最大允许长度</param>
    /// <exception cref="ArgumentException">如果字段长度不在范围内，则抛出异常</exception>
    public static void ValidateFieldLength(string? field, string fieldName, int minLength, int maxLength)
    {
        // 如果字段为空，则不验证
        if (string.IsNullOrEmpty(field))
        {
            return;
        }

        // 验证字段长度范围
        if (field.Length < minLength || field.Length > maxLength)
        {
            throw new ArgumentException($"字段 '{fieldName}' 的长度不在允许范围内，允许范围为 {minLength}-{maxLength}。");
        }
    }

    /// <summary>
    /// 验证整数字段是否小于 0
    /// </summary>
    /// <param name="field">字段值</param>
    /// <param name="fieldName">字段名称（用于错误信息）</param>
    /// <exception cref="ArgumentException">如果字段值小于 0，则抛出异常</exception>
    public static void ValidateNonNegativeInt(int? field, string fieldName)
    {
        // 如果字段为空，则不验证
        if (field == null)
        {
            return;
        }

        // 验证字段是否小于 0
        if (field < 0)
        {
            throw new ArgumentException($"字段 '{fieldName}' 的值不能小于 0。");
        }
    }
}