using MediatR;
using Skills.Domain.Entities;
using Skills.Domain.Repository;
using Skills.Domain.Repository.Skills;

namespace Skills.Application.Modules.Skills.Delete;

public class DeleteSkillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteSkillRequest>
{
    public async Task Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await skillsRepository.FindOne(request.SkillId, cancellationToken)
            ?? throw new EntityNotFoundException<Skill>();

        skillsRepository.Delete(skill);

        await unitOfWork.Save(cancellationToken);
    }
}
