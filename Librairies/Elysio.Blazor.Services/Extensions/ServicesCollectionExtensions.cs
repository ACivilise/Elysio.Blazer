
using Elysio.Blazor.Services.Services;
using Elysio.Blazor.Services.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Elysio.Blazor.Services.Extensions
{
    public static class ServicesCollectionExtensions
    {
        /// <summary>
        /// Ajoute les services à l'injecteur de dépendances
        /// </summary>
        /// <param name="services">L'interface d'enregistrement de l'injecteur
        /// de dépendances</param>
        /// <returns>L'interface d'enregistrement de l'injecteur de dépendances</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IArticlesService, ArticlesService>();
        }

    }
}
