using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Skills.Application.Configuration;
using Skills.Application.Services;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;

namespace Skills.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddSingleton<AppConfiguration>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<PasswordHasher<User>>();
        services.AddScoped<UserSession>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
