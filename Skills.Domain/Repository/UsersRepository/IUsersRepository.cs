using Skills.Domain.Entities;

namespace Skills.Domain.Repository.UsersRepository;

public interface IUsersRepository : IBaseRepository<User>
{
    Task<bool> ExistsByUsername(string username, CancellationToken cancellationToken);
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
    Task<User?> GetWithSkills(Guid id, CancellationToken cancellationToken);
    Task<List<User>> GetAllWithSkills(CancellationToken cancellationToken);
    Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken);
}