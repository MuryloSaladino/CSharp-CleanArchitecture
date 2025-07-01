using MediatR;

namespace Application.Commands.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest;
