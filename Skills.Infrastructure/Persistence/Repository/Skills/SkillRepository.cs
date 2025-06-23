using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.Skills;
using Skills.Infrastructure.Persistence.Context;

namespace Skills.Infrastructure.Persistence.Repository.Skills;

public class SkillRepository(
    SkillsContext context
) : BaseRepository<Skill>(context), ISkillsRepository
{
    public Task<List<Skill>> FindByName(string name, CancellationToken cancellationToken)
        => Context.Set<Skill>()
            .Where(skill => skill.DeletedAt == null)
            .Where(skill => EF.Functions.ILike(skill.Name, $"%{ name }%"))
            .ToListAsync(cancellationToken);
}