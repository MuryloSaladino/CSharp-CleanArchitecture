using Skills.Domain.Common.Exceptions;
using Skills.Domain.Entities;

namespace Skills.Application.Validation;

public class UserSession
{
    public User? User { get; set; } = null;

    public User GetLoggedUserOrThrow()
        => User ?? throw new AppException(ExceptionCode.Unauthorized, ExceptionMessages.Unauthorized.Session);

    public User GetLoggedAdminOrThrow()
    {
        var user = GetLoggedUserOrThrow();

        if (!user.IsAdmin)
            throw new AppException(ExceptionCode.Forbidden, ExceptionMessages.Forbidden.Role);

        return user;
    }
}