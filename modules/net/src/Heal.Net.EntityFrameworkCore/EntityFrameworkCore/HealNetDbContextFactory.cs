using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Heal.Net.EntityFrameworkCore.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class HealNetDbContextFactory : IDesignTimeDbContextFactory<HealNetDbContext>
{
    public HealNetDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        HealNetEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<HealNetDbContext>()
            .UseMySql(configuration.GetConnectionString("Default"), MySqlServerVersion.LatestSupportedServerVersion);
        
        return new HealNetDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Heal.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
