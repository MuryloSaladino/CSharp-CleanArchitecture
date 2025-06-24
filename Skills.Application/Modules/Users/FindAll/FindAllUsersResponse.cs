using Skills.Domain.Entities;

namespace Skills.Application.Modules.Users.FindAll;

public sealed record FindAllUsersResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);