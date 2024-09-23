namespace Skills.Domain.Entities;

using Common;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public List<Skill> Skills { get; set; } = [];
}
