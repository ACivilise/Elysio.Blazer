using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Elysio.Blazor.Data.Context;
using NLog.Web;

namespace Elysio.Blazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                services.MigrateDb().SeedData();
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build())
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostContext, config) =>
                                {
                                    IHostingEnvironment env = hostContext.HostingEnvironment;
                                    // delete all default configuration providers
                                    config.Sources.Clear();
                                    config.AddJsonFile($"Settings\\database.json", optional: true, reloadOnChange: true);
                                    env.ConfigureNLog($"Settings\\nlog.config");
                                })
#if DEBUG
                .UseUrls("http://localhost:15001")
#endif
                .UseNLog() // NLog: setup NLog for Dependency injection
                .Build();
    }
}
