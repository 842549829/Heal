using TinyPinyin;

namespace Heal.Domain.Shared.Extensions;

/// <summary>
/// 汉字转拼音
/// https://github.com/hstarorg/TinyPinyin.Net
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
        return PinyinHelper.GetPinyin(str).ToLower();
    }

    /// <summary> 
    /// 汉字转化为拼音首字母
    /// </summary> 
    /// <param name="str">汉字</param> 
    /// <returns>首字母</returns> 
    public static string GetFirstPinyin(string str)
    {
        return PinyinHelper.GetPinyinInitials(str).ToLower();
    }
}