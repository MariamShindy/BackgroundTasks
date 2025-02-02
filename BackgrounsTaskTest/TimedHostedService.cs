using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgrounsTaskTest
{
    public class TimedHostedService(ILogger<TimedHostedService> _logger) : IHostedService, IDisposable
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Timed Hosted Service is working. Time: {DateTimeOffset.Now}");
            Console.ResetColor();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
