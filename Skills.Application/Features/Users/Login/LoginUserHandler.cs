using MediatR;
using Microsoft.AspNetCore.Identity;
using Skills.Application.Common.Exceptions;
using Skills.Application.Repository.UserRepository;
using Skills.Domain.Contracts;
using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Login;

public sealed class LoginUserHandler(
    IUserRepository userRepository,
    PasswordHasher<User> passwordHasher,
    IAuthenticationService authentication
) : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IUserRepository userRepository = userRepository;
    private readonly PasswordHasher<User> hasher = passwordHasher;
    private readonly IAuthenticationService authentication = authentication;


    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken)
            ?? throw new AppException("User not found", 404);
        
        if(hasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
            throw new AppException("Incorrect credentials", 401);
        
        var token = authentication.GenerateUserToken(user.Id.ToString());
        return new LoginUserResponse(token);
    }
}