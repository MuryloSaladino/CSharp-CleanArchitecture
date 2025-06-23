using AutoMapper;
using MediatR;
using Skills.Domain.Repository.Users;

namespace Skills.Application.Users.FindBySkill;

public sealed class FindUsersBySkillHandler(
    IUsersRepository userRepository,
    IMapper mapper
) : IRequestHandler<FindUsersBySkillRequest, List<FindUsersBySkillResponse>>
{
    public async Task<List<FindUsersBySkillResponse>> Handle(
        FindUsersBySkillRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindBySkillName(request.SkillName ?? "", cancellationToken);

        return mapper.Map<List<FindUsersBySkillResponse>>(user);
    }
}