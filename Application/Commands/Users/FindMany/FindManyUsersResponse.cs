using Domain.Entities;

namespace Application.Commands.Users.FindMany;

public sealed record FindManyUsersResponse(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin,
    List<UserSkill> Skills
);