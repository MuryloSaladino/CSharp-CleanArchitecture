namespace Skills.Application.Usecases.Auth.Login;

public sealed record LoginResponse(
    string AccessToken,
    string RefreshToken
);

