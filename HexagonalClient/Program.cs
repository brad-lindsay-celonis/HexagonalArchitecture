using HexagonalClient.Adapters;
using HexagonalClient.Shell;
using HexagonalDomain.Logging;
using HexagonalDomain.Settings;
using HexagonalDomain.Time;
using HexagonalServices.Logging;
using HexagonalServices.Settings;
using HexagonalServices.Time;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;

namespace HexagonalClient;

internal static class Program
{
    private static void Main(string[] args)
    {
        ConfigureNLog();

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                logging.AddNLog();
            })
            .ConfigureServices((context, services) =>
            {
                services.AddTransient<ISettingsAdapter, SettingsAdapter>();
                services.AddTransient<ISettingsService, SettingsService>();
                services.AddTransient<ILoggingAdapter, NLogAdapter>();
                services.AddTransient<ILoggingService, LoggingService>();
                services.AddTransient<ITimeService, TimeService>();
                services.AddTransient<IShellService, ShellService>();
            }).Build();

        var shell = host.Services.GetRequiredService<IShellService>();
        shell.Run();
    }

    private static void ConfigureNLog()
    {
        var nlogConfiguration = new LoggingConfiguration();
        var consoleTarget = new ConsoleTarget("console") { Layout = "${longdate} ${level:uppercase=true} ${message} ${exception:format=toString}" };
        nlogConfiguration.AddTarget(consoleTarget);
        nlogConfiguration.AddRuleForAllLevels(consoleTarget);
        LogManager.Configuration = nlogConfiguration;
    }
}