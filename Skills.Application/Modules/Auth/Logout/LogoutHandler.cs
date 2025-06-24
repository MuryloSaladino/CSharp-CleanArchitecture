using MediatR;
using Skills.Domain.Identity;
using Skills.Domain.Repository.RefreshTokens;
using Skills.Domain.Repository;

namespace Skills.Application.Modules.Auth.Logout;

public class LogoutHandler(
    IRefreshTokensRepository refreshTokensRepository,
    ISessionContext session,
    IUnitOfWork unitOfWork
) : IRequestHandler<LogoutRequest, LogoutResponse>
{
    public async Task<LogoutResponse> Handle(
        LogoutRequest request, CancellationToken cancellationToken)
    {
        if (session.RefreshToken is string token)
        {
            var refreshToken = await refreshTokensRepository.Find(token, cancellationToken);
            refreshToken?.Invalidate();
            await unitOfWork.Save(cancellationToken);
        }
        
        session.AccessToken = null;
        session.RefreshToken = null;

        return new LogoutResponse();
    }
}
