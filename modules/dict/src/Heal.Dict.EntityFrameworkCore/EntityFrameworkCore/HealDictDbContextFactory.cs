using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Heal.Dict.EntityFrameworkCore.EntityFrameworkCore;

/* This class is needed for EF Core console commands 
 * (like Add-Migration and Update-Database commands) */
public class HealDictDbContextFactory : IDesignTimeDbContextFactory<HealDictDbContext>
{
    /// <summary>
    /// Create a new instance of HealNetDbContext(配置数据库迁移)
    /// </summary>
    /// <param name="args">args</param>
    /// <returns>HealNetDbContext</returns>
    public HealDictDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        HealDictEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<HealDictDbContext>()
            .UseMySQL(configuration.GetConnectionString("Default")!);
            //.UseMySql(configuration.GetConnectionString("Default")!, MySqlServerVersion.LatestSupportedServerVersion); 
        
        return new HealDictDbContext(builder.Options);
    }

    /// <summary>
    /// Build Configuration
    /// </summary>
    /// <returns>IConfigurationRoot</returns>
    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Heal.Dict.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
