using Domain.Entities;
using Domain.Identity;
using Domain.Repository.Users;

namespace Infrastructure.Identity.Context;

public class SessionContext(
    IUsersRepository usersRepository
) : ISessionContext
{
    public Guid? UserId { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }

    public async Task<User> GetUserOrThrow(CancellationToken cancellationToken)
    {
        if (UserId is null) throw new InvalidSessionException();
        return await usersRepository.FindOne(new() { Id = UserId }, cancellationToken);
    }
}