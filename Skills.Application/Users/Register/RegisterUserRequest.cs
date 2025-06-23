using MediatR;

namespace Skills.Application.Users.Register;

public sealed record RegisterUserRequest(
    string Username,
    string Password
) : IRequest<RegisterUserResponse>;
