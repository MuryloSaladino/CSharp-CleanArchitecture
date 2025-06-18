using Skills.Domain.Entities;

namespace Skills.Domain.Repository.UserSkills;

public interface IUserSkillsRepository
{
    void Create(UserSkill userSkill);
    Task Delete(Guid userId, Guid skillId, CancellationToken cancellationToken);
}