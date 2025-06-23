using Skills.Domain.Entities;

namespace Skills.Domain.Repository.RefreshTokens;

public interface IRefreshTokensRepository
{
    void Create(RefreshToken refreshToken);
    Task<RefreshToken?> Find(string token, CancellationToken cancellationToken);
    Task<RefreshToken?> Find(Guid userId, CancellationToken cancellationToken);
}