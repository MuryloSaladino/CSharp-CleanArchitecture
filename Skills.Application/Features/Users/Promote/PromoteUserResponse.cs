namespace Skills.Application.Features.Users.Promote;

public sealed record PromoteUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin
);