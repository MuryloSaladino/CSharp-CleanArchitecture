using Microsoft.EntityFrameworkCore;
using Skills.Application.Repository.UserRepository;
using Skills.Domain.Entities;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.Users;

public class UserRepository(SkillsContext skillsContext) : BaseRepository<User>(skillsContext), IUserRepository
{
    public Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Where(user => user.Skills.Any(skill => skill.Name == skillName))
            .ToListAsync(cancellationToken);
}