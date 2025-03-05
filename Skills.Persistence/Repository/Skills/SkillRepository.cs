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

    public Task<bool> ExistsForUser(Guid id, Guid userId, CancellationToken cancellationToken)
        => dbSet.AnyAsync(skill => 
            skill.Id == id && 
            skill.UserId == userId &&
            skill.DeletedAt == null, 
        cancellationToken);
}