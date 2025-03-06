using AutoMapper;
using MediatR;
using Skills.Domain.Repository.UsersRepository;

namespace Skills.Application.Features.Users.FindBySkill;

public sealed class FindUsersBySkillHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUsersBySkillRequest, List<FindUsersBySkillResponse>>
{
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<List<FindUsersBySkillResponse>> Handle(
        FindUsersBySkillRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetBySkillName(request.SkillNameFilter, cancellationToken);

        return mapper.Map<List<FindUsersBySkillResponse>>(user);
    }
}