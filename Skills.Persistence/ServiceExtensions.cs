using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skills.Application.Config;
using Skills.Domain.Repository;
using Skills.Domain.Repository.SkillsRepository;
using Skills.Domain.Repository.UsersRepository;
using Skills.Persistence.Context;
using Skills.Persistence.Repository;
using Skills.Persistence.Repository.Skills;
using Skills.Persistence.Repository.Users;

namespace Skills.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        var connection = DotEnv.Get("DATABASE_URL");

        services.AddDbContext<SkillsContext>(opt => opt.UseNpgsql(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUsersRepository, UserRepository>();
        services.AddScoped<ISkillsRepository, SkillRepository>();
    }
}