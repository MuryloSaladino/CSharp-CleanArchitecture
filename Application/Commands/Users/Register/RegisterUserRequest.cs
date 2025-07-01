using MediatR;

namespace Application.Commands.Users.Register;

public sealed record RegisterUserRequest(
    string Username,
    string Password
) : IRequest<RegisterUserResponse>;
