using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Configuration;

namespace Infrastructure.Persistence.Seeding;

public static class SeedingExtensions
{
    public static async Task SeedAdmin(this DbContext context, IAppConfiguration appConfig)
    {
        var username = appConfig.GetSecret("ADMIN_USERNAME");
        var password = appConfig.GetSecret("ADMIN_PASSWORD");
        var hasher = new PasswordHasher<User>();
        var userSet = context.Set<User>();

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