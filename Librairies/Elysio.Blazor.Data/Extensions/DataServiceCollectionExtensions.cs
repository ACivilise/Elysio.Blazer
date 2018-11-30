using AutoMapper;
using Elysio.Blazor.Data.AutoMapper;
using Elysio.Blazor.Data.Context;
using Elysio.Blazor.Data.Repositories.Articles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Elysio.Blazor.Data.Extensions
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDatabase(
                                   this IServiceCollection services,
                                   IConfiguration configuration)
        {
            var migrationsAssembly = typeof(MyDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("MyConnection");
            var dbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(builder =>
            {
                builder.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly(migrationsAssembly);
                    options.CommandTimeout(180);
                });
            });

            return services
                .AddDbContext<MyDbContext>(dbContextOptionsBuilder, ServiceLifetime.Scoped)
                .AddScoped<IMyDbContext, MyDbContext>();
        }

        /// <summary>
        /// Ajoute les services à l'injecteur de dépendances
        /// </summary>
        /// <param name="services">L'interface d'enregistrement de l'injecteur
        /// de dépendances</param>
        /// <returns>L'interface d'enregistrement de l'injecteur de dépendances</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IArticlesRepository, ArticlesRepository>();
        }
        
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DTOsProfile>();
            });

            return services;
        }
    }
}

