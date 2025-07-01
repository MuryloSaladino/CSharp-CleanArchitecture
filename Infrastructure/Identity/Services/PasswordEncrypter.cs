using Microsoft.AspNetCore.Identity;
using Domain.Identity;

namespace Infrastructure.Identity.Services;

public class PasswordEncrypter : IPasswordEncrypter
{
    private readonly PasswordHasher<object> _hasher = new();

    public string Hash(string password)
        => _hasher.HashPassword(null!, password);

    public bool Matches(string hash, string password)
        => _hasher.VerifyHashedPassword(null!, hash, password) == PasswordVerificationResult.Success;
}
