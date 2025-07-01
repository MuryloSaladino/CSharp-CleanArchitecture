using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }
    public List<UserSkill> Skills { get; set; } = [];
}
