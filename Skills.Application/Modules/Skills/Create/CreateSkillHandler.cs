using AutoMapper;
using MediatR;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.Skills;

namespace Skills.Application.Modules.Skills.Create;

public class CreateSkillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
{
    public async Task<CreateSkillResponse> Handle(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = mapper.Map<Skill>(request);

        skillsRepository.Create(skill);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateSkillResponse>(skill);
    }
}
