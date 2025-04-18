using System.Text.RegularExpressions;

namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 手机号相关扩展方法
/// </summary>
public static class PhoneExtension
{
    /// <summary>
    /// 验证手机号是否合法
    /// </summary>
    /// <param name="phoneNumber">手机号</param>
    /// <returns>结果</returns>
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        // 验证手机号是否为空
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return false;
        }

        // 验证手机号是否以1开头
        if (!phoneNumber.StartsWith("1"))
        {
            return false;
        }

        // 验证手机号的长度是否为11位
        return phoneNumber.Length == 11 &&
               // 验证手机号的格式是否正确
               Regex.IsMatch(phoneNumber, @"^[1][3-9][0-9]\d{8}$");
    }

    /// <summary>
    /// 手机/座机号码验证
    /// </summary>
    /// <returns></returns>
    public static bool IsValidationTelephoneOrMobile(string phone)
    {
        return IsValidPhoneNumber(phone) || IsValidationTelephone(phone);
    }

    /// <summary>
    /// 座机验证
    /// </summary>
    /// <param name="phone">座机</param>
    /// <returns>结果</returns>
    public static bool IsValidationTelephone(string phone)
    {
        return Regex.IsMatch(phone,
                   @"0\d{2,3}-\d{7,8}|\(?0\d{2,3}[)-]?\d{7,8}|\(?0\d{2,3}[)-]*\d{7,8}");
    }

}