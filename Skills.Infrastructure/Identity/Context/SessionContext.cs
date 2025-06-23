using Skills.Domain.Identity;
using Skills.Domain.Exceptions;

namespace Skills.Infrastructure.Identity.Context;

public class SessionContext : ISessionContext
{
    private Guid? _userId;

    public Guid UserId
    {
        get => _userId ?? throw new AppException(ExceptionCode.Unauthorized, ExceptionMessages.Unauthorized.Session);
        set => _userId = value;
    }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}