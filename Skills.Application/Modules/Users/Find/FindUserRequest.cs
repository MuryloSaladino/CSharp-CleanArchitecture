using MediatR;
using Skills.Application.Pipeline.Authentication;

namespace Skills.Application.Modules.Users.Find;

[Authenticate]
public sealed record FindUserRequest(
    Guid UserId
) : IRequest<FindUserResponse>;