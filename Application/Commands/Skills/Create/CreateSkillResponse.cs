namespace Application.Commands.Skills.Create;

public sealed record CreateSkillResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);
