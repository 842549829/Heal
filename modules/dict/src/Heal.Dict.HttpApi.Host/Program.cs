using Serilog;

namespace Heal.Dict.HttpApi.Host;

/// <summary>
/// 程序启动入口
/// 前端还原 abp install-libs
/// </summary>
public class Program
{
    /// <summary>
    /// 主程序
    /// </summary>
    /// <param name="args">args</param>
    /// <returns>Task</returns>
    public static async Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .CreateLogger();

        try
        {
            Log.Information("Starting Heal.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration)
                        .ReadFrom.Services(services)
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                });

            await builder.AddApplicationAsync<HealDictHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}