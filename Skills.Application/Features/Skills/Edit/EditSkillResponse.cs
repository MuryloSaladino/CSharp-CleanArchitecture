namespace Skills.Application.Features.Skills.Edit;

public sealed record EditSkillResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Name,
    int Level
);