namespace Skills.Application.Features.Skills.Create;

public sealed record CreateSkillResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    int Level
);