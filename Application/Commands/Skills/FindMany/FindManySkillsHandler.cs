using AutoMapper;
using Domain.Repository.Skills;
using MediatR;

namespace Application.Commands.Skills.FindMany;

public class FindManySkillsHandler(
    ISkillsRepository skillsRepository,
    IMapper mapper
) : IRequestHandler<FindManySkillsRequest, List<FindManySkillsResponse>>
{
    public async Task<List<FindManySkillsResponse>> Handle(
        FindManySkillsRequest request, CancellationToken cancellationToken)
    {
        var skills = await skillsRepository.FindMany(request, cancellationToken);

        return mapper.Map<List<FindManySkillsResponse>>(skills);
    }
}
