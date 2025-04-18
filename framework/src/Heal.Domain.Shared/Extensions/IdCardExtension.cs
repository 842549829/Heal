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
    /// 验证身份证合理性
    /// </summary>
    /// <param name="idNumber">身份证号</param>
    /// <returns>结果</returns>
    public static bool IsValidIdCard(string idNumber)
    {
        if (string.IsNullOrWhiteSpace(idNumber))
        {
            return false;
        }
        if (idNumber.Length == 18)
        {
            var check = CheckIdCard18(idNumber);
            return check;
        }
        if (idNumber.Length != 15)
        {
            return false;
        }

        {
            var check = CheckIdCard15(idNumber);
            return check;
        }

        //18位身份证号码验证
        static bool CheckIdCard18(string idNumber)
        {
            if (long.TryParse(idNumber.Remove(17), out var n) == false
                || n < Math.Pow(10, 16)
                || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            //省份编号
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false;//省份验证
            }
            var birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            if (DateTime.TryParse(birth, out _) == false)
            {
                return false;//生日验证
            }
            var arrArrifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            var wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            var ai = idNumber.Remove(17).ToCharArray();
            var sum = 0;
            for (var i = 0; i < 17; i++)
            {
                // 加权求和
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());
            }
            //得到验证码所在位置
            Math.DivRem(sum, 11, out var y);
            var x = idNumber.Substring(17, 1).ToLower();
            var yy = arrArrifyCode[y];
            if (yy != x)
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        //15位身份证号码验证
        static bool CheckIdCard15(string idNumber)
        {
            if (long.TryParse(idNumber, out var n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            const string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(idNumber.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false;//省份验证
            }
            var birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            return DateTime.TryParse(birth, out _);
        }
    }
}