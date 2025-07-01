using Microsoft.Extensions.DependencyInjection;
using Domain.Identity;
using Infrastructure.Identity.Context;
using Infrastructure.Identity.Services;

namespace Infrastructure.Identity;

public static class ServiceExtensions
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<ITokenAuthenticator, TokenAuthenticator>();
        
        services.AddScoped<ISessionContext, SessionContext>();
    }
}