using Microsoft.Extensions.DependencyInjection;
using Application.Configuration;
using Infrastructure.Configuration;
using Domain.Identity;
using Infrastructure.Identity.Services;
using Infrastructure.Identity.Context;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Repository;
using Infrastructure.Persistence.Repository;
using Domain.Repository.Skills;
using Infrastructure.Persistence.Repository.Skills;
using Domain.Repository.Users;
using Infrastructure.Persistence.Repository.Users;
using Infrastructure.Persistence.Seeding;
using Domain.Repository.UserSkills;
using Infrastructure.Persistence.Repository.UserSkills;
using Domain.Repository.RefreshTokens;
using Infrastructure.Persistence.Repository.RefreshTokens;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        // CONFIGURATION
        services.AddSingleton<IAppConfiguration, AppConfiguration>();


        // PERSISTENCE
        services.AddDbContext<SkillsContext>((serviceProvider, options) =>
        {
            var appConfig = serviceProvider.GetRequiredService<IAppConfiguration>();

            options.UseNpgsql(appConfig.GetSecret("DATABASE_URL"));

            if (appConfig.AppEnvironment == AppEnvironment.Development)
                options.UseAsyncSeeding(async (ctx, b, cancellationToken) => await ctx.SeedAdmin(appConfig));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISkillsRepository, SkillRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IUserSkillsRepository, UserSkillsRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
        

        // IDENTITY
        services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<ITokenAuthenticator, TokenAuthenticator>();
        services.AddScoped<ISessionContext, SessionContext>();
    }
}