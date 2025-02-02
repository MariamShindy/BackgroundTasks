using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgrounsTaskTest
{
    public class TimedBackgroundService(ILogger<TimedBackgroundService> _logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Timed Background Service is working. Time: {DateTimeOffset.Now}");
                Console.ResetColor();
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            _logger.LogInformation("Timed Background Service is stopping.");
        }
    }
}
