using MediatR;

namespace Skills.Application.Features.Users.Login;

public sealed record LoginUserRequest(
    string Username,
    string Password
) : IRequest<LoginUserResponse>;