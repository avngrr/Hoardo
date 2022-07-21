using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application.Extensions;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddAutoMapper(Assembly.GetExecutingAssembly());           
    }
}
