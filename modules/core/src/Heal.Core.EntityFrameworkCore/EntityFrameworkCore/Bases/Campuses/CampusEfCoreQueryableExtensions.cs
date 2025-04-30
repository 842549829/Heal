using Heal.Core.Domain.Bases.Campuses.Entities;

namespace Heal.Core.EntityFrameworkCore.EntityFrameworkCore.Bases.Campuses;

/// <summary>
///  entity extension methods.
/// </summary>
public static class CampusEfCoreQueryableExtensions
{
    /// <summary>
    /// Include details.
    /// </summary>
    /// <param name="queryable">IQueryable</param>
    /// <param name="include">include</param>
    /// <returns>Campus</returns>
    public static IQueryable<Campus> IncludeDetails(this IQueryable<Campus> queryable, bool include = true)
    {
        return queryable;
    }
}