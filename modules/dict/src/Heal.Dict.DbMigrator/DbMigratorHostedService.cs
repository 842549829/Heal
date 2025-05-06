using Heal.Dict.Domain.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;

namespace Heal.Dict.DbMigrator;

/// <summary>
/// Hosted service to run database migrations.
/// </summary>
public class DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    : IHostedService
{
    /// <summary>
    /// Constructor.
    /// </summary>
    private readonly IHostApplicationLifetime _hostApplicationLifetime = hostApplicationLifetime;

    /// <summary>
    /// Constructor.
    /// </summary>
    private readonly IConfiguration _configuration = configuration;

    /// <summary>
    /// Starts the database migration.
    /// </summary>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var application = await AbpApplicationFactory.CreateAsync<HealDictDbMigratorModule>(options =>
        {
           options.Services.ReplaceConfiguration(_configuration);
           options.UseAutofac();
           options.Services.AddLogging(c => c.AddSerilog());
           options.AddDataMigrationEnvironment();
        }))
        {
            await application.InitializeAsync();

            await application
                .ServiceProvider
                .GetRequiredService<HealDictDbMigrationService>()
                .MigrateAsync();

            await application.ShutdownAsync();

            _hostApplicationLifetime.StopApplication();
        }
    }

    /// <summary>
    /// Stops the database migration.
    /// </summary>
    /// <param name="cancellationToken">cancellationToken</param>
    /// <returns>Task</returns>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
