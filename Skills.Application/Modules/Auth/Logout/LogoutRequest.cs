using MediatR;
using Skills.Application.Pipeline.Authentication;

namespace Skills.Application.Modules.Auth.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest<LogoutResponse>;