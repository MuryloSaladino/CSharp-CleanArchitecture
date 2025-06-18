using Skills.Domain.Entities;

namespace Skills.Domain.Repository.Users;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
    Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken);
}