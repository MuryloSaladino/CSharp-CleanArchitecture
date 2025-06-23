using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.Configuration;
using Skills.Domain.Repository;
using Skills.Domain.Repository.RefreshTokens;
using Skills.Domain.Repository.Skills;
using Skills.Domain.Repository.Users;
using Skills.Domain.Repository.UserSkills;
using Skills.Infrastructure.Persistence.Context;
using Skills.Infrastructure.Persistence.Repository;
using Skills.Infrastructure.Persistence.Repository.RefreshTokens;
using Skills.Infrastructure.Persistence.Repository.Skills;
using Skills.Infrastructure.Persistence.Repository.Users;
using Skills.Infrastructure.Persistence.Repository.UserSkills;

namespace Skills.Infrastructure.Persistence;

public static class PersistenceConfiguration
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL")
            ?? throw new InvalidConfigurationException("Missing \"DATABASE_URL\" environment variable");

        services.AddDbContext<SkillsContext>(opt => opt.UseNpgsql(dbUrl));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ISkillsRepository, SkillRepository>();
        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<IUserSkillsRepository, UserSkillsRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
    }
}