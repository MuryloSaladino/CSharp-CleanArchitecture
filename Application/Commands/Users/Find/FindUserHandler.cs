using AutoMapper;
using MediatR;
using Domain.Repository.Users;

namespace Application.Commands.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    public async Task<FindUserResponse> Handle(
        FindUserRequest request, CancellationToken cancellationToken)
    {
        var userIdFilter = new UserFilter { Id = request.UserId };
        var user = await userRepository.FindOne(userIdFilter, cancellationToken);

        return mapper.Map<FindUserResponse>(user);
    }
}