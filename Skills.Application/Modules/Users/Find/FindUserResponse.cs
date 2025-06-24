using Skills.Domain.Entities;

namespace Skills.Application.Modules.Users.Find;

public sealed record FindUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);