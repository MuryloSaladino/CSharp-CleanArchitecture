using Domain.Enums;

namespace Domain.Entities;

public class UserSkill
{
    public required Guid UserId { get; set; }
    public required Guid SkillId { get; set; }
    public required Skill Skill { get; set; }

    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public required SkillLevel Level { get; set; }
}