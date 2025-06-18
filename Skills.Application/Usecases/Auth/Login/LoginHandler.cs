using MediatR;
using Skills.Domain.Common.Exceptions;
using Skills.Domain.Repository.Users;
using Skills.Domain.Contracts;
using Skills.Domain.Repository;

namespace Skills.Application.Usecases.Auth.Login;

public sealed class LoginHandler(
    IUsersRepository userRepository,
    IPasswordEncrypter encrypter,
    IAuthenticator authenticator,
    IUnitOfWork unitOfWork
) : IRequestHandler<LoginRequest, LoginResponse>
{
    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken)
            ?? throw new AppException(ExceptionCode.NotFound, ExceptionMessages.NotFound.User);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw new AppException(ExceptionCode.Unauthorized, ExceptionMessages.Unauthorized.Credentials);

        var accessToken = authenticator.GenerateToken(user);
        var refreshToken = Guid.NewGuid().ToString();

        user.RefreshToken = refreshToken; 
        userRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return new LoginResponse(accessToken, refreshToken);
    }
}