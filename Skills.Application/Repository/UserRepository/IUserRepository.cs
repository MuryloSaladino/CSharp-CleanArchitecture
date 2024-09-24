using Skills.Domain.Entities;

namespace Skills.Application.Repository.UserRepository;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetBySkillName(string skillName, CancellationToken cancellationToken);
    Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
}