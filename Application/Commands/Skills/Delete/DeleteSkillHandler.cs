using MediatR;
using Domain.Repository;
using Domain.Repository.Skills;

namespace Application.Commands.Skills.Delete;

public class DeleteSkillHandler(
    ISkillsRepository skillsRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteSkillRequest>
{
    public async Task Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
    {
        var skillIdFilter = new SkillFilter { Id = request.SkillId };
        var skill = await skillsRepository.FindOne(skillIdFilter, cancellationToken);

        skillsRepository.Delete(skill);

        await unitOfWork.Save(cancellationToken);
    }
}
