using Heal.Domain.Entities;

namespace Heal.Net.Domain.Bases.Departments.Entities;

/// <summary>
/// 科室类型
/// </summary>
public class DepartmentType(Guid id, string name) : FullHealthcareAuditedAggregateRoot<Guid>(id, name);