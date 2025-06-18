using MediatR;

namespace Skills.Application.Usecases.Auth.Logout;

public sealed record LogoutRequest : IRequest<LogoutResponse>;