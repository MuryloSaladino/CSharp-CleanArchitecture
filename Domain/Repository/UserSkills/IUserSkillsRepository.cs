using Domain.Entities;

namespace Domain.Repository.UserSkills;

public record UserSkillFilter
{
    public Guid? UserId { get; set; }
    public Guid? SkillId { get; set; }
}

public interface IUserSkillsRepository : IBaseRepository<UserSkill, UserSkillFilter>;
