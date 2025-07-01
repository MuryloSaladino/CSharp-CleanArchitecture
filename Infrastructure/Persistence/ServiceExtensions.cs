using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.Configuration;
using Domain.Repository;
using Domain.Repository.RefreshTokens;
using Domain.Repository.Skills;
using Domain.Repository.Users;
using Domain.Repository.UserSkills;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Repository.RefreshTokens;
using Infrastructure.Persistence.Repository.Skills;
using Infrastructure.Persistence.Repository.Users;
using Infrastructure.Persistence.Repository.UserSkills;
using Infrastructure.Persistence.Seeding;

namespace Infrastructure.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        services.AddDbContext<SkillsContext>(opt =>
        {
            var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
                ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");

            opt.UseNpgsql(dbUrl);

            if(Environment.GetEnvironmentVariable("ENV") == "dev")
                opt.UseAsyncSeeding(async (ctx, b, cancellationToken) => await ctx.SeedAdmin());
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISkillsRepository, SkillRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IUserSkillsRepository, UserSkillsRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
    }
}