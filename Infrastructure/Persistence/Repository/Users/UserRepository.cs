using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repository.Users;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository.Users;

public class UserRepository(SkillsContext context) 
    : BaseRepository<User, UserFilter>(context), IUsersRepository
{
    protected override IQueryable<User> FilterQuery(UserFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.Username is string username)
            query = query.Where(u => u.Username == username);

        if (filter.SkillNamePattern is string pattern)
            query = query.Where(u => u.Skills.Any(skill =>
                EF.Functions.ILike(skill.Skill.Name, $"%{pattern}%")
            ));

        return query;
    }
}