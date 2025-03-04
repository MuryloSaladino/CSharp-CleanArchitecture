using MediatR;

namespace Skills.Application.Features.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest<LoginResponse>;