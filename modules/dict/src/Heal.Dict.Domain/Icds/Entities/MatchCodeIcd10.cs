namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// 匹配码ICD-10
/// </summary>
public class MatchCodeIcd10 : MatchCodeIcd<Guid>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="version">版本</param>
    /// <param name="effectiveStartTime">有效期开始时间</param>
    /// <param name="effectiveEndTime">有效期结束时间</param>
    /// <param name="targetCode">目标Code</param>
    /// <param name="targetName">目标名称</param>
    public MatchCodeIcd10(Guid id, string name, string code, string version, DateTime effectiveStartTime,
        DateTime effectiveEndTime, string targetCode, string targetName) : base(id, name, code, version,
        effectiveStartTime, effectiveEndTime, targetCode, targetName)
    {
    }
}