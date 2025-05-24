
namespace Heal.Dict.Domain.Icds.Entities;

/// <summary>
/// 临床ICD-9
/// </summary>
///  <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">code</param>
/// <param name="version">版本</param>
/// <param name="effectiveStartTime">有效期开始时间</param>
/// <param name="effectiveEndTime">有效期结束时间</param>
public class ClinicalIcd9(
    Guid id,
    string name,
    string code,
    string version,
    DateTime effectiveStartTime,
    DateTime effectiveEndTime)
    : BaseIcd<Guid>(id, name, code, version, effectiveStartTime, effectiveEndTime);