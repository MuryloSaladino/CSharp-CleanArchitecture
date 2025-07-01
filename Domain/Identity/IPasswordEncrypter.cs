namespace Domain.Identity;

public interface IPasswordEncrypter
{
    string Hash(string password);
    bool Matches(string hash, string password);
}