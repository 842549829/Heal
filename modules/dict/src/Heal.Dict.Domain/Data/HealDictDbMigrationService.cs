using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Volo.Abp.DependencyInjection;

namespace Heal.Dict.Domain.Data;

/// <summary>
/// Migrates the database and seed data.
/// </summary>
public class HealDictDbMigrationService : ITransientDependency
{
    /// <summary>
    /// Logger
    /// </summary>
    public ILogger<HealDictDbMigrationService> Logger { get; set; }

    /// <summary>
    /// Database schema migrators
    /// </summary>
    private readonly IEnumerable<IHealDictDbSchemaMigrator> _dbSchemaMigrators;

    /// <summary>
    /// Tenant repository
    /// </summary>
    /// <param name="dbSchemaMigrators">dbSchemaMigrators</param>
    public HealDictDbMigrationService(
        IEnumerable<IHealDictDbSchemaMigrator> dbSchemaMigrators)
    {
        _dbSchemaMigrators = dbSchemaMigrators;

        Logger = NullLogger<HealDictDbMigrationService>.Instance;
    }

    /// <summary>
    /// Migrate the database and seed data.
    /// </summary>
    /// <returns>Task</returns>
    public async Task MigrateAsync()
    {
        var initialMigrationAdded = AddInitialMigrationIfNotExist();

        if (initialMigrationAdded)
        {
            return;
        }

        Logger.LogInformation("Started database migrations...");

        await MigrateDatabaseSchemaAsync();

        Logger.LogInformation($"Successfully completed host database migrations.");

        Logger.LogInformation("You can safely end this process...");
    }

    /// <summary>
    /// Migrate the database schema.
    /// </summary>
    /// <returns>Task</returns>
    private async Task MigrateDatabaseSchemaAsync()
    {
        foreach (var migrator in _dbSchemaMigrators)
        {
            await migrator.MigrateAsync();
        }
    }

    /// <summary>
    /// Add initial migration if not exist.
    /// </summary>
    /// <returns>bool</returns>
    private bool AddInitialMigrationIfNotExist()
    {
        try
        {
            if (!DbMigrationsProjectExists())
            {
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

        try
        {
            if (!MigrationsFolderExists())
            {
                AddInitialMigration();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            Logger.LogWarning("Couldn't determinate if any migrations exist : " + e.Message);
            return false;
        }
    }

    /// <summary>
    /// Check if db migrations project exists.
    /// </summary>
    /// <returns>bool</returns>
    private static bool DbMigrationsProjectExists()
    {
        var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();

        return dbMigrationsProjectFolder != null;
    }

    /// <summary>
    /// Check if migrations folder exists.
    /// </summary>
    /// <returns>bool</returns>
    private static bool MigrationsFolderExists()
    {
        var dbMigrationsProjectFolder = GetEntityFrameworkCoreProjectFolderPath();

        return dbMigrationsProjectFolder != null && Directory.Exists(Path.Combine(dbMigrationsProjectFolder, "Migrations"));
    }

    /// <summary>
    /// Add initial migration.
    /// </summary>
    private void AddInitialMigration()
    {
        Logger.LogInformation("Creating initial migration...");

        string argumentPrefix;
        string fileName;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            argumentPrefix = "-c";
            fileName = "/bin/bash";
        }
        else
        {
            argumentPrefix = "/C";
            fileName = "cmd.exe";
        }

        var procStartInfo = new ProcessStartInfo(fileName,
            $"{argumentPrefix} \"abp create-migration-and-run-migrator \"{GetEntityFrameworkCoreProjectFolderPath()}\"\""
        );

        try
        {
            Process.Start(procStartInfo);
        }
        catch (Exception)
        {
            throw new Exception("Couldn't run ABP CLI...");
        }
    }

    /// <summary>
    /// Get entity framework core project folder path.
    /// </summary>
    /// <returns>result</returns>
    private static string? GetEntityFrameworkCoreProjectFolderPath()
    {
        var slnDirectoryPath = GetSolutionDirectoryPath();

        if (slnDirectoryPath == null)
        {
            throw new Exception("Solution folder not found!");
        }

        var srcDirectoryPath = Path.Combine(slnDirectoryPath, "src");

        return Directory.GetDirectories(srcDirectoryPath)
            .FirstOrDefault(d => d.EndsWith(".EntityFrameworkCore"));
    }

    /// <summary>
    /// Get solution directory path.
    /// </summary>
    /// <returns>directory path</returns>
    private static string? GetSolutionDirectoryPath()
    {
        var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (currentDirectory != null && Directory.GetParent(currentDirectory.FullName) != null)
        {
            currentDirectory = Directory.GetParent(currentDirectory.FullName);

            if (currentDirectory != null && Directory.GetFiles(currentDirectory.FullName).FirstOrDefault(f => f.EndsWith(".sln")) != null)
            {
                return currentDirectory.FullName;
            }
        }

        return null;
    }
}
