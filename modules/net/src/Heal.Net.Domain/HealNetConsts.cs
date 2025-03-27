using Volo.Abp.Identity;

namespace Heal.Net.Domain;

/// <summary>
/// Constants.
/// </summary>
public static class HealNetConsts
{
    /// <summary>
    /// Database tables and schemas.
    /// </summary>
    public const string DbTablePrefix = "App";

    /// <summary>
    /// Database schema.
    /// </summary>
    public const string? DbSchema = null;

    /// <summary>
    /// Default admin email.
    /// </summary>
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;

    /// <summary>
    /// Default admin password.
    /// </summary>
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}
