using Domain.Entities;

namespace Domain.Identity;

public interface ISessionContext
{
    Guid? UserId { get; set; }
    string? AccessToken { get; set; }
    string? RefreshToken { get; set; }
    Task<User> GetUserOrThrow(CancellationToken cancellationToken);
}