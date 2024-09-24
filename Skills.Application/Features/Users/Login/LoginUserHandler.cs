using MediatR;

namespace Skills.Application.Features.Users.Login;

public sealed class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    public Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}