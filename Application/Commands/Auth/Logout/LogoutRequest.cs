using MediatR;
using Application.Attributes;

namespace Application.Commands.Auth.Logout;

[Authenticate]
public sealed record LogoutRequest : IRequest;