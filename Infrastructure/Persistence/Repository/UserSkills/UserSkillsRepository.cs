using Domain.Entities;
using Domain.Repository.UserSkills;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository.UserSkills;

public class UserSkillsRepository(SkillsContext context) 
    : BaseRepository<UserSkill, UserSkillFilter>(context), IUserSkillsRepository
{
    protected override IQueryable<UserSkill> FilterQuery(UserSkillFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.UserId is Guid userId)
            query = query.Where(us => us.UserId == userId);
            
        if (filter.SkillId is Guid skillId)
            query = query.Where(us => us.SkillId == skillId);

        return query;
    }
}
