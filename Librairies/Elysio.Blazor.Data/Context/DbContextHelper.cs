using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Elysio.Blazor.Data.Context
{
    public static class DbContextHelper
    {
        /// <summary>
        /// Effectue les migrations automatiques des bases de données
        /// </summary>
        /// <param name="app">App builder</param>
        /// <returns><paramref name="app"/></returns>
        public static IServiceProvider MigrateDb(this IServiceProvider services)
        {
            MyDbContext applicationContext = services.GetRequiredService<MyDbContext>();

            var pendingMigrations = applicationContext.Database.GetPendingMigrations().ToList();
            if (pendingMigrations.Count > 0)
                applicationContext.Database.Migrate();

            return services;
        }
        /// <summary>
        /// Initialise les données de l'application
        /// </summary>
        /// <param name="app">App builder</param>
        /// <param name="configuration">Configuration</param>
        /// <returns><paramref name="app"/></returns>
        public static IServiceProvider SeedData(this IServiceProvider services)
        {
            IConfiguration configuration = services.GetRequiredService<IConfiguration>();
            MyDbContext applicationContext = services.GetRequiredService<MyDbContext>();
            IConfigurationSection seedConfig = configuration.GetSection("SEED");

            Seed seed;
            if (seedConfig?.GetValue<bool>("Actif") == true) seed = new SeedDev(applicationContext, services);
            else seed = new Seed(applicationContext, services);

            seed.Run().Wait();

            return services;
        }
    }
}
