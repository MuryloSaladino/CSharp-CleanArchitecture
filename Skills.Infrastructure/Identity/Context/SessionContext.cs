using Skills.Domain.Identity;

namespace Skills.Infrastructure.Identity.Context;

public class SessionContext : ISessionContext
{
    private Guid? _userId;

    public Guid UserId
    {
        get => _userId ?? throw new InvalidSessionException();
        set => _userId = value;
    }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}