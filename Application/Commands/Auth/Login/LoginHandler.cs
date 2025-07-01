using MediatR;
using Domain.Repository.Users;
using Domain.Identity;
using Domain.Repository.RefreshTokens;
using Domain.Entities;
using Domain.Repository;
using Application.Exceptions;

namespace Application.Commands.Auth.Login;

public sealed class LoginHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ITokenAuthenticator tokenAuthenticator,
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LoginRequest>
{
    public async Task Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var usernameFilter = new UserFilter { Username = request.Username };
        var user = await userRepository.FindOne(usernameFilter, cancellationToken);
                
        if (!encrypter.Matches(user.Password, request.Password))
            throw new AuthenticationException("Incorrect password or invalid credentials.");

        var userTokenFilter = new RefreshTokenFilter { UserId = user.Id };
        var refreshToken = await refreshTokensRepository.FindOneOrDefault(userTokenFilter, cancellationToken);

        if (refreshToken is null)
        {
            refreshToken = RefreshToken.FromUser(user);
            refreshTokensRepository.Create(refreshToken);
        }

        refreshToken.Rotate();
        await unitOfWork.Save(cancellationToken);

        session.AccessToken = tokenAuthenticator.GenerateToken(TokenPayload.FromUser(user));
        session.RefreshToken = refreshToken.Value;
    }
}