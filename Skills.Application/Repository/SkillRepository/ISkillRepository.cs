using Skills.Domain.Entities;

namespace Skills.Application.Repository.SkillRepository;

public interface ISkillRepository : IBaseRepository<Skill>
{
    Task<List<Skill>> GetByMinLevel(int level, CancellationToken cancellationToken);
}