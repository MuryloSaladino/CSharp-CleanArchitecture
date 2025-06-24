using AutoMapper;
using MediatR;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.Users;

namespace Skills.Application.Modules.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    public async Task<FindUserResponse> Handle(
        FindUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindOne(request.UserId, cancellationToken)
            ?? throw new EntityNotFoundException<User>();

        return mapper.Map<FindUserResponse>(user);
    }
}