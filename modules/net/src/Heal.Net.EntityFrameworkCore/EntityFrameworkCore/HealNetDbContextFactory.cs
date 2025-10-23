using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/* This class is needed for EF Core console commands 
 * (like Add-Migration and Update-Database commands) */
public class HealNetDbContextFactory : IDesignTimeDbContextFactory<HealNetDbContext>
{
    /// <summary>
    /// Create a new instance of HealNetDbContext(配置数据库迁移)
    /// </summary>
    /// <param name="args">args</param>
    /// <returns>HealNetDbContext</returns>
    public HealNetDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        HealNetEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<HealNetDbContext>()
            .UseMySql(configuration.GetConnectionString("Default")!, MySqlServerVersion.LatestSupportedServerVersion); 
        
        return new HealNetDbContext(builder.Options);
    }

    /// <summary>
    /// Build Configuration
    /// </summary>
    /// <returns>IConfigurationRoot</returns>
    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Heal.Net.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
