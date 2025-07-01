using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repository.Skills;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository.Skills;

public class SkillRepository(SkillsContext context) 
    : BaseRepository<Skill, SkillFilter>(context), ISkillsRepository
{
    protected override IQueryable<Skill> FilterQuery(SkillFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.NamePattern is string pattern)
            query = query.Where(s => EF.Functions.ILike(s.Name, $"%{pattern}%"));

        return query;
    }
}