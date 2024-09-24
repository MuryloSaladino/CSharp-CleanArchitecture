using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Skills.Persistence;

public static class ServiceExtensions
{
    public static void ConfigureExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("SkillsContext");
    }
}