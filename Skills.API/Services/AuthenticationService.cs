using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Skills.Domain.Entities;
using Microsoft.IdentityModel.Protocols.Configuration;
using Skills.Domain.Contracts;
using Skills.Domain.Common.Exceptions;
using Skills.Domain.Repository.Users;

namespace Skills.API.Services;

public class AuthenticationService(IUsersRepository usersRepository) : IAuthenticator
{
    private string SecretKey { get; } = Environment.GetEnvironmentVariable("JWT_SECRET_KEY")
        ?? throw new InvalidConfigurationException("The environment needs \"SECRET_KEY\" variable");

    public string GenerateToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            ]),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ),
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(15)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    
    public async Task<User> ExtractUserFromToken(string token, CancellationToken cancellationToken)
    {
        var key = Encoding.ASCII.GetBytes(SecretKey);
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new SecurityTokenException($"Missing { ClaimTypes.NameIdentifier } claim");

            if (!Guid.TryParse(userId, out var parsedId))
                throw new SecurityTokenException($"Invalid { ClaimTypes.NameIdentifier } claim format");

            return await usersRepository.Find(parsedId, cancellationToken)
                ?? throw new Exception(ExceptionMessages.NotFound.User);
        }
        catch (Exception ex)
        {
            throw new AppException(
                ExceptionCode.Unauthorized,
                ExceptionMessages.Unauthorized.Default,
                ex.Message
            );
        }
    }
}

