using Microsoft.EntityFrameworkCore;
using Skills.Application.Repository.SkillRepository;
using Skills.Domain.Entities;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.Skills;

public class SkillRepository(SkillsContext skillsContext) : BaseRepository<Skill>(skillsContext), ISkillRepository
{
    public Task<List<Skill>> GetByMinLevel(int level, CancellationToken cancellationToken)
        => context
            .Set<Skill>()
            .Where(skill => skill.Level >= level)
            .ToListAsync(cancellationToken);
}