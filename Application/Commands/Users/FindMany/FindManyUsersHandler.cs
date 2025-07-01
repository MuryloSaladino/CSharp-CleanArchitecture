using AutoMapper;
using MediatR;
using Domain.Repository.Users;

namespace Application.Commands.Users.FindMany;

public sealed class FindManyUsersHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindManyUsersRequest, List<FindManyUsersResponse>>
{
    public async Task<List<FindManyUsersResponse>> Handle(
        FindManyUsersRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManyUsersResponse>>(user);
    }
}