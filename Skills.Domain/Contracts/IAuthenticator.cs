using Skills.Domain.Entities;

namespace Skills.Domain.Contracts;

public interface IAuthenticator
{
    string GenerateToken(User user);
    Task<User> ExtractUserFromToken(string token, CancellationToken cancellationToken);
}