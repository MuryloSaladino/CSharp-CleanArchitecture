using MediatR;
using Skills.Application.Common.Behaviors;

namespace Skills.Application.Users.Find;

[Authenticate]
public sealed record FindUserRequest(
    Guid UserId
) : IRequest<FindUserResponse>;