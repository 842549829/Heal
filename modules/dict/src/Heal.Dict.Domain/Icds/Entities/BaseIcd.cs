using Heal.Domain.Entities;

namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// 基础ICD
/// </summary>
public abstract class BaseIcd<TKey> : HealthcareAuditedAggregateRoot<TKey>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="version">版本</param>
    /// <param name="effectiveStartTime">有效期开始时间</param>
    /// <param name="effectiveEndTime">有效期结束时间</param>
    protected BaseIcd(TKey id, 
        string name, 
        string code, 
        string version, 
        DateTime effectiveStartTime,
        DateTime effectiveEndTime) : base(id, name, code)
    {
        Version = version;
        EffectiveStartTime = effectiveStartTime;
        EffectiveEndTime = effectiveEndTime;
    }

    /// <summary>
    /// 版本
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// 设置版本
    /// </summary>
    /// <param name="version">版本</param>
    public void SetVersion(string version)
    {
        Version = version;
    }

    /// <summary>
    /// 有效期开始时间
    /// </summary>
    public DateTime EffectiveStartTime { get; private set; }

    /// <summary>
    /// 有效期结束时间
    /// </summary>
    public DateTime EffectiveEndTime { get; private set; }

    /// <summary>
    /// 设置有效期
    /// </summary>
    /// <param name="effectiveStartTime">有效期开始时间</param>
    /// <param name="effectiveEndTime">有效期结束时间</param>
    public void SetEffectiveTime(DateTime effectiveStartTime, DateTime effectiveEndTime)
    {
        EffectiveStartTime = effectiveStartTime;
        EffectiveEndTime = effectiveEndTime;
    }
}