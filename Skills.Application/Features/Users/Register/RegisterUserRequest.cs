using MediatR;

namespace Skills.Application.Features.Users.Register;

public sealed record RegisterUserRequest(
    string Username,
    string Password
) : IRequest<RegisterUserResponse>;
