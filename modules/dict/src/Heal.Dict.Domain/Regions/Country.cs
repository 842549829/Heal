namespace Heal.Dict.Domain.Regions;

/// <summary>
/// 国家
/// </summary>
public class Country : BaseRegion<Guid>
{
    /// <summary>基础聚合根</summary>
    /// <param name="id">id</param>
    /// <param name="name">名称</param>
    /// <param name="code">code</param>
    /// <param name="version">版本</param>
    /// <param name="parentCode">上级编码</param>
    public Country(Guid id, string name, string code, string version, string parentCode) : base(id, name, code, version,
        parentCode)
    {
    }
}