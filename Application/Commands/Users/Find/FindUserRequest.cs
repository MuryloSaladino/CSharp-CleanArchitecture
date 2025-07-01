using MediatR;
using Application.Attributes;

namespace Application.Commands.Users.Find;

[Authenticate]
public sealed record FindUserRequest(
    Guid UserId
) : IRequest<FindUserResponse>;