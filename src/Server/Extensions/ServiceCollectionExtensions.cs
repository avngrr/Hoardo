using Application.Common.Interfaces.Repository;
using Server.Repositories;

namespace Server.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepos(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepositoryAsync<,>), typeof(RepositoryAsync<,>));
        services.AddTransient(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        return services;
    }
}
