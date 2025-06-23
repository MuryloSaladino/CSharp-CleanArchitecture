using MediatR;

namespace Skills.Application.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest<LoginResponse>;
