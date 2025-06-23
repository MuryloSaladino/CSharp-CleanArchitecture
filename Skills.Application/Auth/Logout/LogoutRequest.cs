using MediatR;
using Skills.Application.Common.Behaviors;

namespace Skills.Application.Auth.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest<LogoutResponse>;