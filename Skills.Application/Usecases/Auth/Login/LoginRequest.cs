using MediatR;

namespace Skills.Application.Usecases.Auth.Login;

public sealed record LoginRequest(
    string Username,
    string Password
) : IRequest<LoginResponse>;
