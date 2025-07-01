using MediatR;
using Domain.Identity;
using Domain.Repository.RefreshTokens;
using Domain.Repository;

namespace Application.Commands.Auth.Logout;

public class LogoutHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LogoutRequest>
{
    public async Task Handle(
        LogoutRequest request, CancellationToken cancellationToken)
    {
        if (session.RefreshToken is string token)
        {
            var tokenFilter = new RefreshTokenFilter { Value = token };
            var refreshToken = await refreshTokensRepository.FindOneOrDefault(tokenFilter, cancellationToken);

            refreshToken?.Invalidate();
            await unitOfWork.Save(cancellationToken);
        }
        
        session.AccessToken = null;
        session.RefreshToken = null;
    }
}
