using MediatR;
using Application.Attributes;
using Domain.Repository.Users;

namespace Application.Commands.Users.FindMany;

[Authenticate(AdminOnly = true)]
public sealed record FindManyUsersRequest
    : UserFilter, IRequest<List<FindManyUsersResponse>>;