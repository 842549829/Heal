namespace Heal.Dict.Domain.Shared.Constants;

/// <summary>
/// 字典项常量
/// </summary>
public static class DictItemConstants
{
    /// <summary>
    /// 字典项编码
    /// </summary>
    public const string Code = "DictItem";

    /// <summary>
    /// 字典项别名最大长度
    /// </summary>
    public static int MaxAliasLength { get; set; } = 64;

    /// <summary>
    /// 字典项样式最大长度
    /// </summary>
    public static int MaxStyleLength { get; set; } = 128;

    /// <summary>
    /// 字典项键最大长度
    /// </summary>
    public static int MaxKeyLength { get; set; } = 95;
}