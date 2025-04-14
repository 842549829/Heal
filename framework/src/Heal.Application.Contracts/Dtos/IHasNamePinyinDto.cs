namespace Heal.Application.Contracts.Dtos;

/// <summary>
/// 拼音
/// </summary>
public interface IHasNamePinyinDto : IHasNameDto
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