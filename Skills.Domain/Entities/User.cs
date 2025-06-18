namespace Skills.Domain.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required bool IsAdmin { get; set; }
    public string? RefreshToken { get; set; } = null;
    public List<UserSkill> Skills { get; set; } = [];
}
