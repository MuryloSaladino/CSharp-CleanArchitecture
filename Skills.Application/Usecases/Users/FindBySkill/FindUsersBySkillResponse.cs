using Skills.Domain.Entities;

namespace Skills.Application.Usecases.Users.FindBySkill;

public sealed record FindUsersBySkillResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);