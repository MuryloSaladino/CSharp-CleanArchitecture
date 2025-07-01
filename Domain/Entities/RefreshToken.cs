using System.Security.Cryptography;

namespace Domain.Entities;

public class RefreshToken
{
    public string Value { get; private set; } = GenerateToken();
    public DateTime RevokedAt { get; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(30);

    public required Guid UserId { get; set; }
    public required User User { get; set; }


    private static string GenerateToken()
    {
        var bytes = RandomNumberGenerator.GetBytes(32);
        return Convert.ToBase64String(bytes);
    }

    public void Rotate()
    {
        Value = GenerateToken();
        ExpiresAt = DateTime.UtcNow.AddDays(30);
    }

    public void Invalidate()
    {
        ExpiresAt = DateTime.UtcNow.AddDays(-1);
    }

    public static RefreshToken FromUser(User user)
        => new()
        {
            User = user,
            UserId = user.Id,
        };
}
