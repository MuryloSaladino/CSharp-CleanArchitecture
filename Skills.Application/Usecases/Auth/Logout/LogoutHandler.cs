using Skills.Domain.Exceptions;
using MediatR;
using Skills.Domain.Repository.Users;
using Skills.Application.Validation;
using Skills.Domain.Repository;

namespace Skills.Application.Usecases.Auth.Logout;

public class LogoutHandler(
    IUsersRepository usersRepository,
    UserSession requestSession,
    IUnitOfWork unitOfWork
) : IRequestHandler<LogoutRequest, LogoutResponse>
{
    public async Task<LogoutResponse> Handle(
        LogoutRequest request, CancellationToken cancellationToken)
    {
        var loggedUser = requestSession.GetLoggedUserOrThrow();

        var user = await usersRepository.Find(loggedUser.Id, cancellationToken)
            ?? throw new AppException(ExceptionCode.NotFound, ExceptionMessages.NotFound.User);

        user.RefreshToken = null;
        usersRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return new LogoutResponse();
    }
}
