using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgrounsTaskTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Background Tasks
            /*
             * https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-9.0&tabs=visual-studio
             * In ASP.NET Core, background tasks can be implemented using hosted services.
             * Hosted services are classes that implement the IHostedService interface.
             * These are ideal for running long-running or periodic tasks, such as polling a database, 
             * processing a queue, or sending emails.
             */
            #endregion

            var host = Host.CreateDefaultBuilder(args)
                           .ConfigureServices((hostContext, services) =>
                           {
                               services.AddHostedService<TimedHostedService>();
                               services.AddHostedService<TimedBackgroundService>();
                           })
                           .ConfigureLogging(logging =>
                           {
                               logging.ClearProviders();
                               logging.AddConsole(); 
                           })
                           .Build();
            host.Run();


        }
    }
}
