using Domain.Entities;

namespace Domain.Repository.Users;

public record UserFilter : BaseEntityFilter
{
    public string? Username { get; set; }
    public string? SkillNamePattern { get; set; }
}

public interface IUsersRepository : IBaseRepository<User, UserFilter>;
