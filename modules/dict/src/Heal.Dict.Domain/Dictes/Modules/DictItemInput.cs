using Heal.Domain.Modules;

namespace Heal.Dict.Domain.Dictes.Modules;

/// <summary>
/// 字典项查询参数
/// </summary>
public class DictItemInput : PagedAndSortedAndFilterInput
{
    /// <summary>
    /// 字典类型Id
    /// </summary>
    public required Guid DictTypeId { get; set; }
}