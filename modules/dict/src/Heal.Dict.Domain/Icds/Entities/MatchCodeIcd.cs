namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// 匹配ICD
/// </summary>
/// <typeparam name="TKey">TKey</typeparam>
public abstract class MatchCodeIcd<TKey> : BaseIcd<TKey>
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
    protected MatchCodeIcd(TKey id, string name, string code, string version, DateTime effectiveStartTime,
        DateTime effectiveEndTime, string targetCode, string targetName) :
        base(id, name, code, version, effectiveStartTime, effectiveEndTime)
    {
        TargetCode = targetCode;
        TargetName = targetName;
    }
    
    /// <summary>
    /// 目标Code
    /// </summary>
    public string TargetCode { get; private set; }
    
    /// <summary>
    /// 目标名称
    /// </summary>
    public string TargetName { get; private set; }
    
    /// <summary>
    /// 设置目标Code和名称
    /// </summary>
    /// <param name="targetCode">目标Code</param>
    /// <param name="targetName">目标名称</param>
    public void SetTarget(string targetCode, string targetName)
    {
        TargetCode = targetCode;
        TargetName = targetName;
    }
}