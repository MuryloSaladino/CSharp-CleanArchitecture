using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.SkillsRepository;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.Skills;

public class SkillRepository(SkillsContext skillsContext) : BaseRepository<Skill>(skillsContext), ISkillsRepository
{
    public Task<List<Skill>> GetByMinLevel(int level, CancellationToken cancellationToken)
        => context
            .Set<Skill>()
            .Where(skill => skill.Level >= level)
            .ToListAsync(cancellationToken);
}