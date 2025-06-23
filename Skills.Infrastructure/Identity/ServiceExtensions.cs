using Microsoft.Extensions.DependencyInjection;
using Skills.Domain.Identity;
using Skills.Infrastructure.Identity.Context;
using Skills.Infrastructure.Identity.Services;

namespace Skills.Infrastructure.Identity;

public static class IdentityConfiguration
{
    public static void ConfigureIdentity(this IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<ITokenAuthenticator, TokenAuthenticator>();
        
        services.AddScoped<ISessionContext, SessionContext>();
    }
}