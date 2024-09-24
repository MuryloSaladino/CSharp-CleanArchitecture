using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skills.Application.Repository;
using Skills.Application.Repository.SkillRepository;
using Skills.Application.Repository.UserRepository;
using Skills.Persistence.Context;
using Skills.Persistence.Repository;
using Skills.Persistence.Repository.Skills;
using Skills.Persistence.Repository.Users;

namespace Skills.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("SkillsContext");
        services.AddDbContext<SkillsContext>(opt => opt.UseSqlServer(connection));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
    }
}