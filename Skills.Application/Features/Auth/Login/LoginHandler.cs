using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Contracts;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Auth.Login;

public sealed class LoginHandler(
    IPasswordEncrypter encrypter,
    IUsersRepository userRepository,
    IAuthenticator authentication
) : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IPasswordEncrypter encrypter = encrypter;
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IAuthenticator authentication = authentication;

    public async Task<LoginResponse> Handle(
        LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken)
            ?? throw new AppException("User not found", 404);
        
        if(!encrypter.Matches(user, request.Password)) 
            throw new AppException("Credentials do not match", 401);
        
        var token = authentication.GenerateUserToken(user);

        return new LoginResponse(token);
    }
}