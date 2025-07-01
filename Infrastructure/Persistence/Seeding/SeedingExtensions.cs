using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.Configuration;
using Domain.Entities;

namespace Infrastructure.Persistence.Seeding;

public static class SeedingExtensions
{
    public static async Task SeedAdmin(this DbContext context)
    {
        var userSet = context.Set<User>();
        var username = Environment.GetEnvironmentVariable("ADMIN_USERNAME")
            ?? throw new InvalidConfigurationException("Missing \"ADMIN_USERNAME\" environment variable");
        var password = Environment.GetEnvironmentVariable("ADMIN_PASSWORD")
            ?? throw new InvalidConfigurationException("Missing \"ADMIN_PASSWORD\" environment variable");
        var hasher = new PasswordHasher<User>();

        var adminUser = await userSet
            .Where(u => u.Username == username)
            .FirstOrDefaultAsync();

        if (adminUser is null)
        {
            userSet.Add(new()
            {
                Username = username,
                Password = hasher.HashPassword(null!, password),
                IsAdmin = true,
            });
            await context.SaveChangesAsync();
        }
    }
}