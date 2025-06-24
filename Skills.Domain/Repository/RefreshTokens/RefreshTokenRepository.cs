using Skills.Domain.Entities;

namespace Skills.Domain.Repository.RefreshTokens;

public interface IRefreshTokensRepository
{
    void Create(RefreshToken refreshToken);
    Task<RefreshToken?> FindOneByTokenValue(string token, CancellationToken cancellationToken);
    Task<RefreshToken?> FindOneByUserId(Guid userId, CancellationToken cancellationToken);
}