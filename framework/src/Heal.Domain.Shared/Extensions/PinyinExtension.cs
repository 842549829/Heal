using Microsoft.International.Converters.PinYinConverter;

namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 汉字转拼音
/// </summary>
public static class PinyinExtension
{
    /// <summary> 
    /// 汉字转化为拼音
    /// </summary> 
    /// <param name="str">汉字</param> 
    /// <returns>全拼</returns> 
    public static string GetPinyin(string str)
    {
        var r = string.Empty;
        foreach (var obj in str)
        {
            try
            {
                var chineseChar = new ChineseChar(obj);
                var t = chineseChar.Pinyins[0];
                r += t[..^1];
            }
            catch
            {
                r += obj.ToString();
            }
        }
        return r;
    }

    /// <summary> 
    /// 汉字转化为拼音首字母
    /// </summary> 
    /// <param name="str">汉字</param> 
    /// <returns>首字母</returns> 
    public static string GetFirstPinyin(string str)
    {
        var r = string.Empty;
        foreach (var obj in str)
        {
            try
            {
                var chineseChar = new ChineseChar(obj);
                var t = chineseChar.Pinyins[0];
                r += t[..1];
            }
            catch
            {
                r += obj.ToString();
            }
        }
        return r;
    }
}