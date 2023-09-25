using Microsoft.Extensions.Logging;
using SampleConsole.Contracts;

namespace SampleConsole;

public class App
{
    private readonly IParser _parser;
    private readonly ILogger<App> _logger;
    public App(IParser parser, ILogger<App> logger)
    {
        _parser = parser;
        _logger = logger;    
    }
    public async Task RunAsync(string[] args)
    {
        _logger.LogInformation("RunAsync method called");
        Console.WriteLine("RunAsync method called");
        await _parser.ParseAsync();
    }
}
