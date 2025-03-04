using Skills.Domain.Entities;

namespace Skills.Application.Features.Users.Find;

public sealed record FindUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    List<Skill> Skills
);