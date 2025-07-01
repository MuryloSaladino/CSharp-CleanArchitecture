using AutoMapper;
using MediatR;
using Domain.Entities;
using Domain.Repository;
using Domain.Repository.Skills;

namespace Application.Commands.Skills.Create;

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
