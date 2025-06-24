using AutoMapper;
using MediatR;
using Skills.Domain.Repository.Users;

namespace Skills.Application.Modules.Users.FindAll;

public sealed class FindAllUsersHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindAllUsersRequest, List<FindAllUsersResponse>>
{
    public async Task<List<FindAllUsersResponse>> Handle(
        FindAllUsersRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.Find(request.SkillName, cancellationToken);

        return mapper.Map<List<FindAllUsersResponse>>(user);
    }
}