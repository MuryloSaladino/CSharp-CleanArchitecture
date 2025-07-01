using Domain.Entities;

namespace Domain.Repository.RefreshTokens;

public record RefreshTokenFilter
{
    public string? Value { get; set; }
    public Guid? UserId { get; set; }
}

public interface IRefreshTokensRepository : IBaseRepository<RefreshToken, RefreshTokenFilter>;