using Microsoft.EntityFrameworkCore;
using Skills.Domain.Entities;
using Skills.Domain.Repository.RefreshTokens;
using Skills.Infrastructure.Persistence.Context;

namespace Skills.Infrastructure.Persistence.Repository.RefreshTokens;

public class RefreshTokensRepository(
    SkillsContext context
) : IRefreshTokensRepository
{
    public void Create(RefreshToken refreshToken)
        => context.Add(refreshToken);

    public Task<RefreshToken?> FindOneByTokenValue(string token, CancellationToken cancellationToken)
        => context.Set<RefreshToken>()
            .Where(rt => rt.Value == token)
            .FirstOrDefaultAsync(cancellationToken);

    public Task<RefreshToken?> FindOneByUserId(Guid userId, CancellationToken cancellationToken)
        => context.Set<RefreshToken>()
            .Where(rt => rt.UserId == userId)
            .FirstOrDefaultAsync(cancellationToken);
}
