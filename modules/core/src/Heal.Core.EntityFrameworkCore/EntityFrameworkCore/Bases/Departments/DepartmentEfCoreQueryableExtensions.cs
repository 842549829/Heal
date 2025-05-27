using Heal.Core.Domain.Bases.Departments.Entities;
using Microsoft.EntityFrameworkCore;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Departments;

/// <summary>
/// DepartmentEfCoreQueryableExtensions
/// </summary>
public static class DepartmentEfCoreQueryableExtensions
{
    /// <summary>
    /// Include details.
    /// </summary>
    /// <param name="queryable">IQueryable</param>
    /// <param name="include">include</param>
    /// <returns>Campus</returns>
    public static IQueryable<Department> IncludeDetails(this IQueryable<Department> queryable, bool include = true)
    {
        return include ? queryable.Include(x => x.Campus) : queryable;
        //return include ?  queryable.Include(x => x.Campus).Include(x => x.DepartmentType) : queryable;
    }
}