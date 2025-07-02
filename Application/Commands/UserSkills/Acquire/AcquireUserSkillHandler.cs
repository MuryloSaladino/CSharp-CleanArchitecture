using Domain.Identity;
using Domain.Repository;
using Domain.Repository.Skills;
using Domain.Repository.UserSkills;
using MediatR;

namespace Application.Commands.UserSkills.Acquire;

public class AcquireSkillHandler(
    IUserSkillsRepository userSkillsRepository,
    ISkillsRepository skillsRepository,
    ISessionContext sessionContext,
    IUnitOfWork unitOfWork
) : IRequestHandler<AcquireSkillRequest>
{
    public async Task Handle(AcquireSkillRequest request, CancellationToken cancellationToken)
    {
        var user = await sessionContext.GetUserOrThrow(cancellationToken);
        var skill = await skillsRepository.FindOne(new() { Id = request.SkillId }, cancellationToken);

        userSkillsRepository.Create(new()
        {
            Level = request.Level,
            Skill = skill,
            SkillId = skill.Id,
            UserId = user.Id,
        });

        await unitOfWork.Save(cancellationToken);
    }
}
