using MediatR;

namespace Skills.Application.Features.Users.Find;

public sealed record FindUserRequest(
    string Id
) : IRequest<FindUserResponse>;