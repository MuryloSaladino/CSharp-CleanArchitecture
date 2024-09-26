namespace Skills.Domain.Contracts;

public interface IAuthenticationService {
    string GenerateUserToken(string userId);
}