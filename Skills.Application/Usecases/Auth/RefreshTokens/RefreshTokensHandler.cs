using Skills.Domain.Common.Exceptions;
using MediatR;
using Skills.Domain.Repository.Users;
using Skills.Domain.Contracts;
using Skills.Domain.Repository;

namespace Skills.Application.Usecases.Auth.RefreshTokens;

public class RefreshTokensHandler(
    IUsersRepository usersRepository,
    IAuthenticator authenticator,
    IUnitOfWork unitOfWork
) : IRequestHandler<RefreshTokensRequest, RefreshTokensResponse>
{
    public async Task<RefreshTokensResponse> Handle(
        RefreshTokensRequest request, CancellationToken cancellationToken)
    {
        var user = await usersRepository.Find(request.UserId, cancellationToken)
            ?? throw new AppException(ExceptionCode.NotFound, ExceptionMessages.NotFound.User);

        if (user.RefreshToken != request.RefreshToken)
            throw new AppException(ExceptionCode.Unauthorized, ExceptionMessages.Unauthorized.RefreshToken);

        var accessToken = authenticator.GenerateToken(user);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken;
        usersRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return new RefreshTokensResponse(accessToken, refreshToken);
    }
}
