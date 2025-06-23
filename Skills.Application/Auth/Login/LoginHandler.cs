using MediatR;
using Skills.Domain.Repository.Users;
using Skills.Domain.Identity;
using Skills.Domain.Repository.RefreshTokens;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Application.Common.Exceptions;

namespace Skills.Application.Auth.Login;

public sealed class LoginHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ITokenAuthenticator tokenAuthenticator,
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindByUsername(request.Username, cancellationToken)
            ?? throw new EntityNotFoundException<User>();
        
        if(!encrypter.Matches(user.Password, request.Password)) 
            throw new AuthenticationException("Incorrect password or invalid credentials.");

        var refreshToken = await refreshTokensRepository.Find(user.Id, cancellationToken)
            ?? RefreshToken.FromUser(user);

        refreshToken.Rotate();
        await unitOfWork.Save(cancellationToken);

        session.AccessToken = tokenAuthenticator.GenerateToken(TokenPayload.FromUser(user));
        session.RefreshToken = refreshToken.Value;

        return new LoginResponse();
    }
}