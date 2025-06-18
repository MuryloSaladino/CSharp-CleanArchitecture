using Microsoft.AspNetCore.Identity;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;

namespace Skills.API.Services;

public class PasswordEncrypterService : IPasswordEncrypter
{
    private readonly PasswordHasher<User> hasher = new();

    public string Hash(User user)
        => hasher.HashPassword(user, user.Password);
    
    public bool Matches(User user, string password)
    {
        var result = hasher.VerifyHashedPassword(user, user.Password, password);
        return result == PasswordVerificationResult.Success;
    }
}