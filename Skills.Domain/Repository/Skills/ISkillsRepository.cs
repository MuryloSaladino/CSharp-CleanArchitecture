using Skills.Domain.Entities;

namespace Skills.Domain.Repository.Skills;

public interface ISkillsRepository : IBaseRepository<Skill>
{
    Task<List<Skill>> FindByName(string name, CancellationToken cancellationToken);
}