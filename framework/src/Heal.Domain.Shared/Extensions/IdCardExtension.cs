namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 身份证扩展
/// </summary>
public static class IdCardExtension
{
    /// <summary>
    /// 根据身份证获取出生日期
    /// </summary>
    /// <param name="idCard">身份证</param>
    /// <returns>生日</returns>

    public static DateTime? GetBirthdayFromIdCard(string idCard)
    {
        // 验证身份证长度是否为15位或18位
        if (!IsValidIdCard(idCard))
        {
            return null; // 返回 null 表示无效输入
        }

        var birthDateStr =
            // 提取15位身份证的出生日期部分（第7到12位）
            idCard.Substring(6, idCard.Length == 15 ? 6 :
            // 提取18位身份证的出生日期部分（第7到14位）
            8);

        // 根据身份证号码长度处理日期格式
        string formattedBirthDateStr;
        if (birthDateStr.Length == 6)
        {
            // 获取身份证上的年份后两位数字
            var idCardYearLastTwoDigits = int.Parse(birthDateStr[..2]);

            // 动态推断世纪前缀
            var currentYear = DateTime.Now.Year;
            var yearPrefix = CalculateCenturyPrefix(currentYear, idCardYearLastTwoDigits);

            // 拼接完整的年份
            formattedBirthDateStr = $"{yearPrefix + idCardYearLastTwoDigits}-{birthDateStr.Substring(2, 2)}-{birthDateStr.Substring(4, 2)}";
        }
        else
        {
            // 如果是18位身份证，直接使用完整日期
            formattedBirthDateStr = $"{birthDateStr[..4]}-{birthDateStr.Substring(4, 2)}-{birthDateStr.Substring(6, 2)}";
        }

        // 尝试将字符串转换为日期
        if (DateTime.TryParseExact(formattedBirthDateStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var birthday))
        {
            return birthday;
        }

        return null; // 如果解析失败，返回 null

        // 计算身份证年份前缀
        int CalculateCenturyPrefix(int currentYear, int idCardYearLastTwoDigits)
        {
            // 计算当前年份所属的世纪
            var currentCentury = currentYear / 100 * 100;

            // 推断身份证号码所属的世纪
            var candidateYear1 = currentCentury + idCardYearLastTwoDigits; // 当前世纪
            var candidateYear2 = currentCentury - 100 + idCardYearLastTwoDigits; // 上一个世纪

            // 如果候选年份1比当前年份大，则选择候选年份2
            return (candidateYear1 > currentYear) ? candidateYear2 : candidateYear1;
        }
    }

    /// <summary>
    /// 验证身份证
    /// </summary>
    /// <param name="idCard">身份证</param>
    /// <returns>是否有效身份证</returns>
    public static bool IsValidIdCard(string idCard)
    {
        if (string.IsNullOrEmpty(idCard))
        {
            return false;
        }

        if (idCard.Length == 15)
        {
            // 将15位身份证号码升级为18位
            idCard = ConvertTo18DigitId(idCard);
        }

        if (idCard.Length != 18)
        {
            return false;
        }

        // 验证省份代码
        if (!IsValidProvinceCode(idCard[..2]))
        {
            return false;
        }

        // 验证前17位是否为数字
        for (var i = 0; i < 17; i++)
        {
            if (!char.IsDigit(idCard[i]))
            {
                return false;
            }
        }

        // 验证第18位是否为数字或字母X（大小写均可）
        var lastChar = char.ToUpper(idCard[17]);
        if (!char.IsDigit(lastChar) && lastChar != 'X')
        {
            return false;
        }

        // 权重因子
        int[] weights = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];

        // 校验码对照表
        char[] checkCodes = ['1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2'];

        // 计算加权和
        var sum = 0;
        for (var i = 0; i < 17; i++)
        {
            sum += (idCard[i] - '0') * weights[i];
        }

        // 计算余数
        var remainder = sum % 11;

        // 获取计算出的校验码
        var calculatedCheckCode = checkCodes[remainder];

        // 比较计算出的校验码与身份证号码的第18位
        return calculatedCheckCode == lastChar;

        //检查省份代码是否合法
        static bool IsValidProvinceCode(string provinceCode)
        {
            // 定义合法的省份代码
            var validProvinceCodes = new HashSet<string>
            {
                "11", "12", "13", "14", "15", "21", "22", "23",
                "31", "32", "33", "34", "35", "36", "37", "41",
                "42", "43", "44", "45", "46", "50", "51", "52",
                "53", "54", "61", "62", "63", "64", "65"
            };

            // 检查省份代码是否合法
            return validProvinceCodes.Contains(provinceCode);
        }

        // 转化成18位身份证
        static string ConvertTo18DigitId(string idCard15)
        {
            // 前6位不变
            var idCard18 = idCard15[..6];

            // 中间6位加上世纪前缀
            var currentYearLastTwoDigits = DateTime.Now.Year % 100;
            var idCardYearLastTwoDigits = int.Parse(idCard15.Substring(6, 2));

            var yearPrefix = (idCardYearLastTwoDigits <= currentYearLastTwoDigits) ? 20 : 19;
            idCard18 += $"{yearPrefix}{idCard15.Substring(6, 6)}";

            // 添加默认的"1231"作为顺序码（实际应用中可能需要更精确的规则）
            idCard18 += "1231";

            // 计算校验码
            int[] weights = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
            char[] checkCodes = ['1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2'];

            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                sum += (idCard18[i] - '0') * weights[i];
            }

            var remainder = sum % 11;
            var checkCode = checkCodes[remainder];

            // 返回完整的18位身份证号码
            return idCard18 + checkCode;
        }
    }
}