namespace Application.Commands.Skills.FindMany;

public sealed record FindManySkillsResponse(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Name
);