using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgrounsTaskTest
{
    public class WorkerService (ILogger<WorkerService> _logger) :  BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker Service started.");

            var timer = new PeriodicTimer(TimeSpan.FromSeconds(5));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Worker Service executing at {DateTimeOffset.Now}");
                 Console.ResetColor();
            }
        }
    }
}
