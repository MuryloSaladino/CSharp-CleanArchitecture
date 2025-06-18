using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;
using Skills.Domain.Entities;
using Skills.Persistence.Context;

namespace Skills.Persistence.Seeding;

public static class SeedingExtensions
{
    private static readonly string AdminUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME")
        ?? throw new InvalidConfigurationException("Missing \"ADMIN_USERNAME\" environment variable");
    private static readonly string AdminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD")
        ?? throw new InvalidConfigurationException("Missing \"ADMIN_PASSWORD\" environment variable");

    public static async Task SeedData(this SkillsContext context)
    {
        var users = context.Set<User>();
        var adminExists = await users.AnyAsync(u => u.Username == AdminUsername);

        if(!adminExists)
        {
            var adminUser = new User()
            {
                Username = AdminUsername,
                Password = AdminPassword,
                IsAdmin = true
            };

            PasswordHasher<User> hasher = new();
            adminUser.Password = hasher.HashPassword(adminUser, adminUser.Password); 
            
            users.Add(adminUser);
        }

        await context.SaveChangesAsync();
    }
}