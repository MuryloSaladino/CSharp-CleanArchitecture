using Skills.Domain.Entities;

namespace Skills.Domain.Contracts;

public interface IPasswordEncrypter
{
    string Hash(User user);
    bool Matches(User user, string password);
}