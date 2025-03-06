namespace Skills.Application.Features.Users.FindBySkill;

public sealed record FindUsersBySkillResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username
);