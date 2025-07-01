using Domain.Entities;
using Domain.Repository.RefreshTokens;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository.RefreshTokens;

public class RefreshTokensRepository(SkillsContext context) 
    : BaseRepository<RefreshToken, RefreshTokenFilter>(context), IRefreshTokensRepository
{
    protected override IQueryable<RefreshToken> FilterQuery(RefreshTokenFilter filter)
    {
        var query = base.FilterQuery(filter);

        if (filter.UserId is Guid userId)
            query = query.Where(rt => rt.UserId == userId);

        if (filter.Value is string value)
            query = query.Where(rt => rt.Value == value);

        return query;
    }
}
