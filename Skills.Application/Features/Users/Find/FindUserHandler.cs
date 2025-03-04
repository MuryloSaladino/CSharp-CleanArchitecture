using AutoMapper;
using MediatR;
using Skills.Application.Common.Exceptions;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Users.Find;

public sealed class FindUserHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUserRequest, FindUserResponse>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<FindUserResponse> Handle(FindUserRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetWithSkills(Guid.Parse(request.Id), cancellationToken)
            ?? throw new AppException("User not found", 404);

        return mapper.Map<FindUserResponse>(user);
    }
}