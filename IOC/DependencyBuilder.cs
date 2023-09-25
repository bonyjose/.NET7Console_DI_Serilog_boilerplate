using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleConsole.Contracts;
using Serilog;

namespace SampleConsole.IOC
{
    internal static class DependencyBuilder
    {
        public static void RegisterDependencies(IServiceCollection  services)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog();
            });

            // Register the LoggerFactory and ILogger<App> for your App class
            services.AddSingleton<ILoggerFactory>(loggerFactory);
            //services.AddTransient<ILogger<App>, Logger<App>>();
            services.AddSingleton<App>();
            services.AddTransient<IParser, JsonParser>();
            //return services.BuildServiceProvider();
        }
    }
}
