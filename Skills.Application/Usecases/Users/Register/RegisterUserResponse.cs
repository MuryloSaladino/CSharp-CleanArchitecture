namespace Skills.Application.Usecases.Users.Register;

public sealed record RegisterUserResponse(
    string Id,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    DateTime? DeletedAt,
    string Username,
    bool IsAdmin
);