using Application.Common.Interfaces.Searchers;
using Application.Features.SearchEngines;
using IMDbApiLib;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(sp => new ApiLib("k_2h0ogv6o"));
        services.AddScoped<ISearchEngine, ImdbSearcher>();
        return services;
    }
}
