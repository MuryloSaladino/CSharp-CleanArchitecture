using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence;
using Infrastructure.Identity;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.ConfigurePersistence();
        services.ConfigureIdentity();
    }
}