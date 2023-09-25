using Microsoft.Extensions.Logging;

namespace SampleConsole.Contracts
{
    internal class JsonParser : IParser
    {
        private readonly ILogger _logger;
        public JsonParser(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<JsonParser>();
        }
        public async Task ParseAsync()
        {
            _logger.LogInformation("JsonParser.ParseAsync method called");
            await Task.Run(() =>
                Console.WriteLine("JsonParser.ParseAsync method called")
                );
        }
    }
}
