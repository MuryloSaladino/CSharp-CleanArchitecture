using MediatR;

namespace Skills.Application.Usecases.Users.Find;

public sealed record FindUserRequest(
    Guid UserId
) : IRequest<FindUserResponse>;