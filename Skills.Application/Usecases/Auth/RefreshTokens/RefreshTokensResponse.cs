namespace Skills.Application.Usecases.Auth.RefreshTokens;

public sealed record RefreshTokensResponse(
    string AccessToken,
    string RefreshToken
);