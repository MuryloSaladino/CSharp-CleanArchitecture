using Skills.Domain.Common;
using Skills.Domain.Entities;

namespace Skills.Domain.Contracts;

public interface IAuthenticator {
    string GenerateUserToken(User user);
    UserSession ExtractToken(string token);
}