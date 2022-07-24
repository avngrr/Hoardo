using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //return services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
