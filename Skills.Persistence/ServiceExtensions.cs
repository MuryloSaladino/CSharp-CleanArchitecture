using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.Configuration;
using Skills.Domain.Repository;
using Skills.Domain.Repository.Skills;
using Skills.Domain.Repository.Users;
using Skills.Domain.Repository.UserSkills;
using Skills.Persistence.Context;
using Skills.Persistence.Repository;
using Skills.Persistence.Repository.Skills;
using Skills.Persistence.Repository.Users;
using Skills.Persistence.Repository.UserSkills;

namespace Skills.Persistence;

public static class ServiceExtensions
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
    }
}