namespace Heal.Domain.Entities;

/// <summary>
/// 组织实体扩展
/// </summary>
public interface IHasNamePinyin : IHasName
{
    /// <summary>
    /// 拼音
    /// </summary>
    string Pinyin { get; }

    /// <summary>
    /// 拼音首字母
    /// </summary>
    string PinyinFirstLetters { get; }
}