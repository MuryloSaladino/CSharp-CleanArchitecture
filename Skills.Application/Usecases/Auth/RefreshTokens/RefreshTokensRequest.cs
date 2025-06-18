using MediatR;

namespace Skills.Application.Usecases.Auth.RefreshTokens;

public sealed record RefreshTokensRequest(
    Guid UserId,
    string RefreshToken
) : IRequest<RefreshTokensResponse>;