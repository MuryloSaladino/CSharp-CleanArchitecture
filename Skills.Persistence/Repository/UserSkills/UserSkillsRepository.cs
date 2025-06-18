using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.UserSkills;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.UserSkills;

public class UserSkillsRepository(
    SkillsContext context
) : IUserSkillsRepository
{
    public void Create(UserSkill userSkill)
        => context.Add(userSkill);

    public Task Delete(Guid userId, Guid skillId, CancellationToken cancellationToken)
        => context.Set<UserSkill>()
            .Where(userSkill => userSkill.UserId == userId)
            .Where(userSkill => userSkill.SkillId == skillId)
            .ExecuteDeleteAsync(cancellationToken);
}
