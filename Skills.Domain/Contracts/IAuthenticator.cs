using Skills.Domain.Common;

namespace Skills.Domain.Contracts;

public interface IAuthenticator {
    string GenerateUserToken(string userId, string username);
    UserSession ExtractToken(string token);
}