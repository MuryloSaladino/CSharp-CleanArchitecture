using MediatR;

namespace Skills.Application.Modules.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest<LoginResponse>;
