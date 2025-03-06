using MediatR;

namespace Skills.Application.Features.Users.Promote;

public sealed record PromoteUserRequest(
    string Id
) : IRequest<PromoteUserResponse>;
