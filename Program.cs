using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleConsole;
using SampleConsole.IOC;
using Serilog;

internal class Program
{
    private async static Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        Log.Information("Application Starting");
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                DependencyBuilder.RegisterDependencies(services);
                services.BuildServiceProvider();
            })
            .UseSerilog()
            .Build();
        using var serviceScope = host.Services.CreateScope();
        var services = serviceScope.ServiceProvider;
        var app = services.GetRequiredService<App>();

        await app.RunAsync(args);

        Log.Information("Application Ending");
        Console.ReadLine();
    }
    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}