using Skills.Domain.Entities;

namespace Skills.Domain.Repository.SkillsRepository;

public interface ISkillsRepository : IBaseRepository<Skill>
{
    Task<List<Skill>> GetByMinLevel(int level, CancellationToken cancellationToken);
}