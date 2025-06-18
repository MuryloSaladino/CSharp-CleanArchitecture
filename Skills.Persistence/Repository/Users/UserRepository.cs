using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.Users;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.Users;

public class UserRepository(
    SkillsContext context
) : BaseRepository<User>(context), IUsersRepository
{
    public Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.Username == username)
            .AnyAsync(cancellationToken);

    public Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.DeletedAt == null)
            .Where(user => user.Skills.Any(skill => skill.Skill.Name == skillName))
            .ToListAsync(cancellationToken);

    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        => Context.Set<User>()
            .Where(user => user.DeletedAt == null)
            .Where(user => user.Username == username)
            .FirstOrDefaultAsync(cancellationToken);
}