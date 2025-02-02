using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgrounsTaskTest
{
    public class SimpleTaskService(ILogger<SimpleTaskService> _logger) : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Simple task service started");
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Simple Task Service is running at {DateTimeOffset.Now}");
                    Console.ResetColor();
                    await Task.Delay(5000);
                }
            },cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Simple Task Service is stopping.");
            return Task.CompletedTask;
        }
    }
}
