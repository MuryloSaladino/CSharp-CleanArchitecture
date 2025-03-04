using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.UsersRepository;
using Skills.Persistence.Context;

namespace Skills.Persistence.Repository.Users;

public class UserRepository(SkillsContext skillsContext) : BaseRepository<User>(skillsContext), IUsersRepository
{
    public Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .FirstOrDefaultAsync(user => user.Username == username, cancellationToken);

    public Task<User?> GetWithSkills(Guid id, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Include(user => user.Skills)
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

    public Task<List<User>> GetAllWithSkills(CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Include(user => user.Skills)
            .ToListAsync(cancellationToken);

    public Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken)
        => context
            .Set<User>()
            .Where(user => user.Skills.Any(skill => skill.Name == skillName))
            .Include(user => user.Skills)
            .ToListAsync(cancellationToken);
}