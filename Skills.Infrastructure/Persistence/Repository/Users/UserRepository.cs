using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.Users;
using Skills.Infrastructure.Persistence.Context;

namespace Skills.Infrastructure.Persistence.Repository.Users;

public class UserRepository(
    SkillsContext context
) : BaseRepository<User>(context), IUsersRepository
{
    public Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.Username == username)
            .AnyAsync(cancellationToken);

    public Task<List<User>> FindBySkillName(string skillName, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.DeletedAt == null)
            .Where(user => skillName == string.Empty || user.Skills.Any(skill => skill.Skill.Name == skillName))
            .ToListAsync(cancellationToken);

    public Task<User?> FindByUsername(string username, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.DeletedAt == null)
            .Where(user => user.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
}