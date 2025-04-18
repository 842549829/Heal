using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Extensions;

namespace Heal.Domain.Entities;

/// <summary>
/// 完整人员审计聚合根
/// </summary>
/// <typeparam name="TKey">主键类型</typeparam>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">代码</param>
/// <param name="idCardType">证件类型</param>
/// <param name="idCardNo">证件号码</param>
/// <param name="gender">性别</param>
/// <param name="phone">手机</param>
public abstract class FullPersonnelAuditedAggregateRoot<TKey>(TKey id, string name, string code, string idCardType, string idCardNo, string gender, string phone)
    : FullHealthcareAuditedAggregateRoot<TKey>(id, name, code), IHasUserBaseInfoExtension
{
    /// <summary>
    /// 国家代码
    /// </summary>
    public string? NationCode { get; private set; }

    /// <summary>
    /// 省份代码
    /// </summary>
    public string? ProvinceCode { get; private set; }

    /// <summary>
    /// 市代码
    /// </summary>
    public string? CityCode { get; private set; }

    /// <summary>
    /// 区代码
    /// </summary>
    public string? DistrictCode { get; private set; }

    /// <summary>
    /// 街道
    /// </summary>
    public string? Street { get; private set; }

    /// <summary>
    /// 地址
    /// </summary>
    public string? AddressLine { get; private set; }

    /// <summary>
    /// 岁
    /// </summary>
    public int Year { get; private set; }

    /// <summary>
    /// 月
    /// </summary>
    public int Month { get; private set; }

    /// <summary>
    /// 天
    /// </summary>
    public int Day { get; private set; }

    /// <summary>
    /// 证件类型
    /// </summary>
    public string IdCardType { get; private set; } = idCardType;

    /// <summary>
    /// 身份号码
    /// </summary>
    public string IdCardNo { get; private set; } = idCardNo;

    /// <summary>
    /// 性别
    /// </summary>
    public string Gender { get; private set; } = gender;

    /// <summary>
    /// 生日
    /// </summary>
    public DateTime Birthday { get; private set; }

    /// <summary>
    /// 电话
    /// </summary>
    public string Phone { get; private set; } = phone;

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; private set; }

    /// <summary>
    /// 设置证件信息
    /// </summary>
    /// <param name="idCardType">证件类型</param>
    /// <param name="idCardNo">证件号</param>
    public void SetIdCard(string idCardType, string idCardNo)
    {
        IdCardType = idCardType;
        IdCardNo = idCardNo;

        if (IdCardType != IdCardConsts.IdCardType01)
        {
            return;
        }

        var birthday = IdCardExtension.GetBirthdayFromIdCard(idCardNo);
        if (birthday == null)
        {
            throw new ArgumentException("身份证号码错误");
        }
        SetBirthday(birthday.Value);
    }

    /// <summary>
    /// 设置生日
    /// </summary>
    /// <param name="birthday">生日</param>
    public void SetBirthday(DateTime birthday)
    {
        Birthday = birthday;
        var (years, months, days) = CalculateAge(birthday);
        Year = years;
        Month = months;
        Day = days;
    }

    /// <summary>
    /// 设置邮箱
    /// </summary>
    /// <param name="email">邮箱</param>
    public void SetEmail(string? email)
    {
        Email = email;
    }

    /// <summary>
    /// 设置年龄
    /// </summary>
    /// <param name="year">年</param>
    /// <param name="month">月</param>
    /// <param name="day">天</param>
    public void SetAge(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;

        Birthday = new DateTime(year, month, day);
    }

    /// <summary>
    /// 设置地址信息
    /// </summary>
    /// <param name="nationCode">国家</param>
    /// <param name="provinceCode">省</param>
    /// <param name="cityCode">市</param>
    /// <param name="districtCode">区</param>
    /// <param name="street">街道</param>
    /// <param name="addressLine">地址</param>
    public void SetAddress(string nationCode, string provinceCode, string cityCode, string districtCode, string street,
        string addressLine)
    {
        NationCode = nationCode;
        ProvinceCode = provinceCode;
        CityCode = cityCode;
        DistrictCode = districtCode;
        Street = street;
        AddressLine = addressLine;
    }

    /// <summary>
    /// 计算年龄并返回年龄、月份和天数
    /// </summary>
    /// <param name="dateOfBirth">出生日期</param>
    /// <returns>年龄信息</returns>
    public static Tuple<int, int, int> CalculateAge(DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        var ageSpan = today - dateOfBirth;
        var years = ageSpan.Days / 365;
        var remainingDays = ageSpan.Days % 365;
        var months = remainingDays / 30;
        var days = remainingDays % 30;

        // 调整月份和天数
        if (today.Month < dateOfBirth.Month || (today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day))
        {
            years--;
            months += 12;
        }

        if (months < 0)
        {
            months += 12;
            years--;
        }

        if (months >= 12)
        {
            years++;
            months -= 12;
        }

        // 调整天数
        if (days < 0)
        {
            months--;
            days += 30;
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }

        return Tuple.Create(years, months, days);
    }
}